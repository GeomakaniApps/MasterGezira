using AutoMapper;
using Core.Infrastruture.RepositoryPattern.Repository;
using DataLayer.Models;
using Domain.DTOs;
using Domain.Helper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Domain.DTOs.GetMemberDto;
using static Domain.DTOs.MembersProfilePicturesDto;
using static Domain.DTOs.MemberDto;
using DataLayer.Services.Pagination;

namespace Domain.Services
{
    public class MemberService(IRepository<Member> _memberReposatory,IMembersProfilePicturesService _ImageService, IMapper _mapper, IChangeLogService _changeLogService , IMembersAttachmentService _attachmentService ,IHistoryLogService _historyLogService) : IMemberService
    {
        public async Task<MemberResult> CreateAsync(MemberDto memberDto)
        {
            var result = new MemberResult();
           
            var NameMember = _memberReposatory.Find(n => n.Name.ToLower() == memberDto.Name.ToLower());
            if (NameMember != null)
                return Helper.Helper.CreateErrorResult<MemberResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("Member"));
            if (_memberReposatory.Find(n => n.NationalId == memberDto.NationalId) != null)
                return Helper.Helper.CreateErrorResult<MemberResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("Member"));
            Member member = _mapper.Map<Member>(memberDto);
            member.JoinDate = DateOnly.FromDateTime(DateTime.UtcNow);
            _changeLogService.SetCreateChangeLogInfo(member);
            await _memberReposatory.AddAsync(member);
            if (memberDto.Image != null)
            {
                var imageResult = await _ImageService.CreateAsync(new MembersProfilePicturesDto
                {
                    Image = memberDto.Image,
                    memberId = member.Id,
                });
                if (imageResult.StatusCode == HttpStatusCode.Created)
                {
                    member.MembersProfilePicturesId = imageResult.Image.Id;
                    memberDto.Base64Image = imageResult.Image.Base64Image;
                    await _memberReposatory.UpdateAsync(member);
                }
            }
            if (memberDto.Attachments != null)
            {
                foreach (var attachmentDto in memberDto.Attachments)
                {
                    attachmentDto.MemberId = member.Id; 
                }

                var attachmentResult = await _attachmentService.CreateAsync(memberDto.Attachments);
            }


            result.Member = memberDto;
            result.SuccessMessage = MessageEnum.Created(typeof(Member).Name);
            result.StatusCode = HttpStatusCode.Created;
            return result;
        }
        public async Task<MemberResult> DeleteAsync(int id)
        {
            var result = new MemberResult();
            string prop = "AttachmentMembers";
          
            var member = await _memberReposatory.GetByIdAsync(id , includeProperties:prop);
            if (member == null)
                return Helper.Helper.CreateErrorResult<MemberResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Member"));
            if (member.IsDeleted == true)
                return Helper.Helper.CreateErrorResult<MemberResult>(HttpStatusCode.BadRequest, "Member already Deleted");
           
            if (member.MembersProfilePicturesId.HasValue)
            {
                await _ImageService.DeleteAsync(member.MembersProfilePicturesId.Value);
            }
            if (member.AttachmentMembers.Any())
            {
                await _attachmentService.DeleteAsync(id);
            }
            _changeLogService.SetDeleteChangeLogInfo(member);
            member.IsDeleted = true;
            await _memberReposatory.UpdateAsync(member);
            result.SuccessMessage = MessageEnum.Deleted(typeof(Member).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetMemberResult> GetAllAsync()
        {
            var result = new GetMemberResult();
            List<string> prop = new List<string>
                    {
                        "City",
                        "Job",
                        "Nationality",
                        "MemberType",
                        "Section",
                        "Area",
                        "Qualification",
                        "Transformation"
                    };

            string includeProperties = string.Join(",", prop);
            var members = await _memberReposatory.GetAllAsync(includeProperties:includeProperties);

            if (!members.Any())
                return Helper.Helper.CreateErrorResult<GetMemberResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Member"));

            var membersDto = _mapper.Map<List<GetMemberDto>>(members);
           
            result.Members = membersDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Member).Name);
            result.StatusCode = HttpStatusCode.OK;

            return result;
        }


        //public async Task<GetMemberResult> GetAsync(int id)
        //{
        //    var result = new GetMemberResult();
        //    List<string> prop = new List<string>
        //            {
        //                "City",
        //                "Job",
        //                "Nationality",
        //                "MemberType",
        //                "Section",
        //                "Area",
        //                "Qualification",
        //                "Transformation"
        //            };

        //    //string includeProperties = string.Join(",", prop);
        //    //var members = await _memberReposatory.GetAllAsync(includeProperties: includeProperties);
        //    var member = await _memberReposatory.FindAsync(id);
        //    if (member == null)
        //        return Helper.Helper.CreateErrorResult<GetMemberResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Member"));
        //    var memberDto = _mapper.Map<GetMemberDto>(member);
        //    if (memberDto.ImageId.HasValue)
        //    {
        //        var image = await _ImageService.GetAsync(memberDto.ImageId.Value);
        //        if (image != null)
        //        {
        //            memberDto.Image = image.GetImag.Base64Image;
        //        }
        //    }
        //    result.Member = memberDto;
        //    result.SuccessMessage = MessageEnum.Getted(typeof(Member).Name);
        //    result.StatusCode = HttpStatusCode.OK;
        //    return result;
        //}
        public async Task<GetMemberResult> GetByIdAsync(int id)
        {
            var result = new GetMemberResult();
            List<string> prop = new List<string>
                    {
                        "City",
                        "Job",
                        "Nationality",
                        "MemberType",
                        "Section",
                        "Area",
                        "Qualification",
                        "Transformation",
                        "MembersPictures",
                        "AttachmentMembers"
                    };

            string includeProperties = string.Join(",", prop);

            var member = await _memberReposatory.GetByIdAsync(id, includeProperties: includeProperties);

            if (member == null)
                return Helper.Helper.CreateErrorResult<GetMemberResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Member"));

            var memberDto = _mapper.Map<GetMemberDto>(member);
            result.Member = memberDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Member).Name);
            result.StatusCode = HttpStatusCode.OK;

            return result;
        }


        public async Task<MemberResult> UpdateAsync(int id, MemberDto memberDto)
        {
            var result = new MemberResult();
            string prop = "AttachmentMembers";
            var member = await _memberReposatory.GetByIdAsync(id , includeProperties:prop);
            if (member == null)
                return Helper.Helper.CreateErrorResult<MemberResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Member"));
            //   var oldMember = await _memberReposatory.GetByIdAsync(id, includeProperties: prop);
            var oldMember = new Member();
            _mapper.Map(member, oldMember);
            if (member.IsDeleted == true)
                return Helper.Helper.CreateErrorResult<MemberResult>(HttpStatusCode.BadRequest, "Member already Deleted");
            var existingMember = _memberReposatory.Find(n => n.Name.ToLower() == memberDto.Name.ToLower() && n.Id != id);
            if (existingMember != null)
                return Helper.Helper.CreateErrorResult<MemberResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("Member"));
            if (_memberReposatory.Find(n => n.NationalId == memberDto.NationalId && n.Id != id) != null)
                return Helper.Helper.CreateErrorResult<MemberResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("National Id"));

            _mapper.Map(memberDto, member);
            _changeLogService.SetUpdateChangeLogInfo(member);
            await _memberReposatory.UpdateAsync(member);
            if (memberDto.Image != null)
            {
                if (member.MembersProfilePicturesId.HasValue)
                {
                    await _ImageService.DeleteAsync(member.MembersProfilePicturesId.Value);
                }

                var imageResult = await _ImageService.CreateAsync(new MembersProfilePicturesDto
                {
                    Image = memberDto.Image,
                    memberId = member.Id,
                });
                if (imageResult.StatusCode == HttpStatusCode.Created)
                {
                    member.MembersProfilePicturesId = imageResult.Image.Id;
                    memberDto.Base64Image = imageResult.Image.Base64Image;
                    await _memberReposatory.UpdateAsync(member);
                }
            }
            if (memberDto.Attachments != null)
            {
                foreach (var attachmentsDto in memberDto.Attachments)
                {
                    attachmentsDto.MemberId = member.Id;
                }
                await _attachmentService.UpdateAsync(id,memberDto.Attachments);

            }

            await _historyLogService.CompareAndLogMemberChanges(member, oldMember,  actionOwner: (int)member.UpdateBy);

            result.Member = memberDto;
            result.SuccessMessage = MessageEnum.Updated(typeof(Member).Name);
            result.StatusCode = HttpStatusCode.OK;

            return result;
        }

        public async Task<GetMemberResult> Filter(List<FilterDTO> filterDTOs, UserParams userParams)
        {
            var result = new GetMemberResult();

            var filterList = filterDTOs.ToList();

            List<string> prop = new List<string>
                {
                    "City", "Job", "Nationality", "MemberType", "Section",
                    "Area", "Qualification", "Transformation" ,"MembersPictures" ,"AttachmentMembers"
                };

            var includePropertiesList = prop;

            var membersPagedList = await _memberReposatory.FilterAll(filterList, userParams , includeProperties:includePropertiesList);
            
            if (!membersPagedList.Any())
            {
                return Helper.Helper.CreateErrorResult<GetMemberResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Member"));
            }
            var membersDtoList = membersPagedList
                    .Select(item => _mapper.Map<GetMemberDto>(item.Data))  
                    .ToList();



            result.Members = membersDtoList;
            result.SuccessMessage = MessageEnum.Getted(typeof(Member).Name);
            result.StatusCode = HttpStatusCode.OK;
            result.Count = membersPagedList.Count;
            return result;
        }


      
   }

 }

