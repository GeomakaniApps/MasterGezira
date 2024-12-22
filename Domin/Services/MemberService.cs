using AutoMapper;
using Core.Infrastruture.RepositoryPattern.Repository;
using DataLayer.Models;
using Domain.DTOs;
using Domain.Helper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Domain.DTOs.GetMemberDto;
using static Domain.DTOs.ImageMemberAndMembRefDto;
using static Domain.DTOs.MemberDto;

namespace Domain.Services
{
    public class MemberService(IRepository<Member> _memberReposatory,IImageMemberAndMembRefService _ImageService, IMapper _mapper, IChangeLogService _changeLogService) : IMemberService
    {
        public async Task<MemberResult> CreateAsync(MemberDto memberDto)
        {
            var result = new MemberResult();
            //var lastMemberCodeId = await _memberReposatory.FindLastAsync("MemberCode");
            //int nextMemberCodeId = (lastMemberCodeId != null) ? lastMemberCodeId.MemberCode + 1 : 1;

            var NameMember = _memberReposatory.Find(n => n.Name.ToLower() == memberDto.Name.ToLower());
            if (NameMember != null)
                return Helper.Helper.CreateErrorResult<MemberResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("Member"));
            Member member = _mapper.Map<Member>(memberDto);
         //   member.MemberCode = nextMemberCodeId;
            member.JoinDate = DateOnly.FromDateTime(DateTime.UtcNow);
        //    member.UserId = _changeLogService.GetUserId();
            _changeLogService.SetCreateChangeLogInfo(member);
            await _memberReposatory.AddAsync(member);
            if (memberDto.Image != null)
            {
                var imageResult = await _ImageService.CreateAsync(new ImageMemberAndMembRefDto
                {
                    Image = memberDto.Image,
                    memberId = member.Id,
                });
                if (imageResult.StatusCode == HttpStatusCode.Created)
                {
                    member.ImageId = imageResult.Image.Id;
                    await _memberReposatory.UpdateAsync(member);
                }
            }
            
            result.Member = memberDto;
            result.SuccessMessage = MessageEnum.Created(typeof(Member).Name);
            result.StatusCode = HttpStatusCode.Created;
            return result;
        }
        public async Task<MemberResult> DeleteAsync(int id)
        {
            var result = new MemberResult();
            var member = await _memberReposatory.GetByIdAsync(id);
            if (member == null)
                return Helper.Helper.CreateErrorResult<MemberResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Member"));
            if (member.ImageId.HasValue)
            {
                await _ImageService.DeleteAsync(member.ImageId.Value);
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


        public async Task<GetMemberResult> GetAsync(int id)
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

            //string includeProperties = string.Join(",", prop);
            //var members = await _memberReposatory.GetAllAsync(includeProperties: includeProperties);
            var member = await _memberReposatory.GetByIdAsync(id);
            if (member == null)
                return Helper.Helper.CreateErrorResult<GetMemberResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Member"));
            var memberDto = _mapper.Map<GetMemberDto>(member);
            if (memberDto.ImageId.HasValue)
            {
                var image = await _ImageService.GetAsync(memberDto.ImageId.Value);
                if (image != null)
                {
                    memberDto.Image = image.GetImag.Base64Image;
                }
            }
            result.Member = memberDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Member).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<MemberResult> UpdateAsync(int id, MemberDto memberDto)
        {
            var result = new MemberResult();

            var member = await _memberReposatory.GetByIdAsync(id);
            if (member == null)
                return Helper.Helper.CreateErrorResult<MemberResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Member"));

            var existingMember = _memberReposatory.Find(n => n.Name.ToLower() == memberDto.Name.ToLower() && n.Id != id);
            if (existingMember != null)
                return Helper.Helper.CreateErrorResult<MemberResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("Member"));

            _mapper.Map(memberDto, member);
            _changeLogService.SetUpdateChangeLogInfo(member);
            await _memberReposatory.UpdateAsync(member);
            if (memberDto.Image != null)
            {
                if (member.ImageId.HasValue)
                {
                    await _ImageService.DeleteAsync(member.ImageId.Value);
                }

                var imageResult = await _ImageService.CreateAsync(new ImageMemberAndMembRefDto
                {
                    Image = memberDto.Image,
                    memberId = member.Id,
                });
                if (imageResult.StatusCode == HttpStatusCode.Created)
                {
                    member.ImageId = imageResult.Image.Id;
                    await _memberReposatory.UpdateAsync(member);
                }
            }

           
           

            result.Member = memberDto;
            result.SuccessMessage = MessageEnum.Updated(typeof(Member).Name);
            result.StatusCode = HttpStatusCode.OK;

            return result;
        }

    }
}
