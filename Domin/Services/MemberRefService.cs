using AutoMapper;
using Core.Infrastruture.RepositoryPattern.Repository;
using Core.Infrastruture.UnitOfWork;
using DataLayer.Models;
using Domain.DTOs;
using Domain.Helper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static Domain.DTOs.MemberRefDto;

namespace Domain.Services;

public class MemberRefService(IRepository<MembersRef> _memberRefRepository, IRepository<Member> _memberRepository, IRepository<Reference> _referenceRepository, IRepository<Section> _sectionRepository, IMembersProfilePicturesService _imageService, IMapper _mapper, IChangeLogService _changeLogService , IHistoryLogService _historyLogService) : IMemberRefService
{


    public async Task<MemberRefResult> CreateAsync(MemberRefDto memberRefDto)
    {
        var result = new MemberRefResult();

        var existingMemberRef = _memberRefRepository.Find(n => n.Name.ToLower() == memberRefDto.Name.ToLower());
        if (existingMemberRef != null)
            return Helper.Helper.CreateErrorResult<MemberRefResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("MemberRef"));

        if (!await _memberRepository.ValidateExistenceAsync(m => m.MemberCode == memberRefDto.MemberCode))
    {
        return Helper.Helper.CreateErrorResult<MemberRefResult>(HttpStatusCode.BadRequest, ErrorEnum.NotFoundMessage("MemberCode"));
    }

    if (!await _referenceRepository.ValidateExistenceAsync(r => r.Id == memberRefDto.ReferenceId))
    {
        return Helper.Helper.CreateErrorResult<MemberRefResult>(HttpStatusCode.BadRequest, ErrorEnum.NotFoundMessage("Reference"));
    }

    if (memberRefDto.SectionId.HasValue && 
        !await _sectionRepository.ValidateExistenceAsync(s => s.Id == memberRefDto.SectionId.Value))
    {
        return Helper.Helper.CreateErrorResult<MemberRefResult>(HttpStatusCode.BadRequest, ErrorEnum.NotFoundMessage("Section"));
    }
        

        var memberRef = _mapper.Map<MembersRef>(memberRefDto);
        memberRef.JoinDate = memberRefDto.JoinDate ?? DateOnly.FromDateTime(DateTime.UtcNow);

        _changeLogService.SetCreateChangeLogInfo(memberRef);

        await _memberRefRepository.AddAsync(memberRef);

        if (memberRefDto.Image != null)
        {
            var imageResult = await _imageService.CreateAsync(new MembersProfilePicturesDto
            {
                Image = memberRefDto.Image,
                memberRefId = memberRef.Id,
            });

            if (imageResult.StatusCode == HttpStatusCode.Created)
            {
                memberRef.ImageId = imageResult.Image.Id;
                await _memberRefRepository.UpdateAsync(memberRef);
            }
        }

        result.MemberRef = memberRefDto;
        result.SuccessMessage = MessageEnum.Created(typeof(MembersRef).Name);
        result.StatusCode = HttpStatusCode.Created;

        return result;
    }


    public async Task<MemberRefResult> DeleteAsync(int id)
    {
        var result = new MemberRefResult();
        var memberRef = await _memberRefRepository.GetByIdAsync(id);
        if (memberRef == null)
            return Helper.Helper.CreateErrorResult<MemberRefResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("MemberRef"));
        if (memberRef.IsDeleted == true)
            return Helper.Helper.CreateErrorResult<MemberRefResult>(HttpStatusCode.BadRequest, "Member reference Already Deleted");

        memberRef.IsDeleted = true;
        _changeLogService.SetDeleteChangeLogInfo(memberRef);
        await _memberRefRepository.UpdateAsync(memberRef);
        result.SuccessMessage = MessageEnum.Deleted(typeof(MembersRef).Name);
        result.StatusCode = HttpStatusCode.OK;

        return result;
    }



    public async Task<MemberRefResult> GetAsync(int id)
    {
        var result = new MemberRefResult();
        var memberRef = await _memberRefRepository.GetByIdAsync(id);
        if (memberRef == null)
            return Helper.Helper.CreateErrorResult<MemberRefResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("MemberRef"));

        var memberRefDto = _mapper.Map<MemberRefDto>(memberRef);
        result.MemberRef = memberRefDto;
        result.SuccessMessage = MessageEnum.Getted(typeof(MembersRef).Name);
        result.StatusCode = HttpStatusCode.OK;

        return result;
    }

    public async Task<MemberRefResult> UpdateAsync(int id, MemberRefDto memberRefDto)
    {
        var result = new MemberRefResult();
        var memberRef = await _memberRefRepository.GetByIdAsync(id);
        var oldMemberRef = new MembersRef();    
        _mapper.Map(memberRef ,oldMemberRef);
        if (memberRef == null)
            return Helper.Helper.CreateErrorResult<MemberRefResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("MemberRef"));

        _mapper.Map(memberRefDto, memberRef);
        _changeLogService.SetUpdateChangeLogInfo(memberRef);
        await _memberRefRepository.UpdateAsync(memberRef);
        await _historyLogService.CompareAndLogMemberRefChanges(memberRef, oldMemberRef, (int)memberRef.UpdateBy);
        result.MemberRef = memberRefDto;
        result.SuccessMessage = MessageEnum.Updated(typeof(MembersRef).Name);
        result.StatusCode = HttpStatusCode.OK;

        return result;
    }
}
