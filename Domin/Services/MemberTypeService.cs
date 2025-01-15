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

namespace Domain.Services
{
    public class MemberTypeService(IRepository<MemberType> _memberTyperepository , IMapper _mapper , IChangeLogService _changeLogService , IHistoryLogService _historyLogService) : IMemberTypeService
    {
        public async Task<MemberTypeResult> CreateAsync(MemberTypeDto memberTypeDto)
        {
            var result = new MemberTypeResult();
            if (_memberTyperepository.Find(n => n.Name.ToLower() == memberTypeDto.Name.ToLower()) !=null)
                return Helper.Helper.CreateErrorResult<MemberTypeResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("memberType"));
            var memberType = _mapper.Map<MemberType>(memberTypeDto);
            _changeLogService.SetCreateChangeLogInfo(memberType);
            await _memberTyperepository.AddAsync(memberType);
            result.MemberType = memberTypeDto;
            result.SuccessMessage = MessageEnum.Created(typeof(MemberType).Name);
            result.StatusCode = HttpStatusCode.Created;
            return result;
        }

        public async Task<MemberTypeResult> DeleteAsync(int id)
        {
            var result = new MemberTypeResult();
            var memberType = await _memberTyperepository.GetByIdAsync(id);
            if (memberType == null)
                return Helper.Helper.CreateErrorResult<MemberTypeResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("MemberType"));
            if (memberType.IsDeleted == true)
                return Helper.Helper.CreateErrorResult<MemberTypeResult>(HttpStatusCode.BadRequest,"Member Type already deleted");
            memberType.IsDeleted = true;  
            _changeLogService.SetDeleteChangeLogInfo(memberType);
             await _memberTyperepository.UpdateAsync(memberType);
             result.SuccessMessage = MessageEnum.Deleted(typeof(Transformation).Name);
            return result;
        }

        public async Task<GetMemberTypeResult> GetAsync(int id)
        {
            var result = new GetMemberTypeResult();
            var memberType = await _memberTyperepository.GetByIdAsync(id);
            if (memberType == null)
                return Helper.Helper.CreateErrorResult<GetMemberTypeResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("MemberType"));
            var memberTypeDto = _mapper.Map<GetMemberTypeDto>(memberType);
            result.MemberType = memberTypeDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(MemberType).Name);
            return result;
        }

        public async Task<GetMemberTypeResult> FindAllIsDeleteFalseAsync()
        {
            var result = new GetMemberTypeResult();
            var memberTypeCondition = (Expression<Func<MemberType, bool>>)(mt => mt.IsDeleted == false);
            var memberType = await _memberTyperepository.FindAllAsync(memberTypeCondition);
            if (!memberType.Any())
                return Helper.Helper.CreateErrorResult<GetMemberTypeResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundAny("MemberType"));
            var memberTypeDto = _mapper.Map<List<GetMemberTypeDto>>(memberType);
            result.MemberTypes = memberTypeDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(MemberType).Name);
            return result;
        }
         public async Task<GetMemberTypeResult> GetAllAsync()
        {
            var result = new GetMemberTypeResult();
            var memberType = await _memberTyperepository.GetAllAsync();
            if (!memberType.Any())
                return Helper.Helper.CreateErrorResult<GetMemberTypeResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundAny("MemberType"));
            var memberTypeDto = _mapper.Map<List<GetMemberTypeDto>>(memberType);
            result.MemberTypes = memberTypeDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(MemberType).Name);
            return result;
        }

        public async Task<MemberTypeResult> UpdateAsync(int id, MemberTypeDto memberTypeDto)
        {
            var result = new MemberTypeResult();
            var memberType = await _memberTyperepository.GetByIdAsync(id);
            var oldMemberType = new MemberType();   
            _mapper.Map(memberType , oldMemberType);
            if (memberType == null)
                return Helper.Helper.CreateErrorResult<MemberTypeResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("MemberType"));
            var isDuplicateName = _memberTyperepository.Find(t => t.Name.ToLower() == memberTypeDto.Name.ToLower() && t.id != id);
            if (isDuplicateName != null)
                return Helper.Helper.CreateErrorResult<MemberTypeResult>(HttpStatusCode.Conflict, ErrorEnum.Existed("MemberType"));
            _mapper.Map(memberTypeDto, memberType);
            _changeLogService.SetUpdateChangeLogInfo(memberType);
            await _memberTyperepository.UpdateAsync(memberType);
            await _historyLogService.CompareAndLogMemberTypeChanges(memberType , oldMemberType , (int)memberType.UpdateBy);
            result.MemberType = memberTypeDto;
            result.SuccessMessage = MessageEnum.Updated(typeof(MemberType).Name);
            return result;
        }
    }
}
