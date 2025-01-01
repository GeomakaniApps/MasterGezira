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

namespace Domain.Services
{
    public class LateFeesService(IRepository<LateFees> _lateFeesRepository,IMapper _mapper , IChangeLogService _changeLogService) : ILateFeesService
    {
        public async Task<LateFeesResult> CreateAsync(LateFeesDto lateFeesDto)
        {
            var result = new LateFeesResult();
            LateFees lateFees = _mapper.Map<LateFees>(lateFeesDto);
            _changeLogService.SetCreateChangeLogInfo(lateFees);
            await _lateFeesRepository.AddAsync(lateFees);
            result.LateFees = lateFeesDto;
            result.SuccessMessage = MessageEnum.Created(typeof(LateFees).Name);
            result.StatusCode=HttpStatusCode.Created;
            return result;
        }

        public async Task<LateFeesResult> DeleteAsync(int id)
        {
            var result = new LateFeesResult();
            var lateFee = await _lateFeesRepository.GetByIdAsync(id);
            if (lateFee == null)
                return Helper.Helper.CreateErrorResult<LateFeesResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("late fees"));
            if (lateFee.IsDeleted==true)
                return Helper.Helper.CreateErrorResult<LateFeesResult>(HttpStatusCode.BadRequest, "Late fee is already deleted");
            lateFee.IsDeleted = true;
            _changeLogService.SetDeleteChangeLogInfo(lateFee);
            await _lateFeesRepository.UpdateAsync(lateFee);
            result.SuccessMessage = MessageEnum.Deleted(typeof(LateFees).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetLateFeesResult> GetAllAsync()
        {
            var result = new GetLateFeesResult();
            var lateFees=await _lateFeesRepository.GetAllAsync();
            if (!lateFees.Any())
                return Helper.Helper.CreateErrorResult<GetLateFeesResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundAny("late fees"));
            var lateFeesDto = _mapper.Map<List<GetLateFeesDto>>(lateFees);
            result.LateFees = lateFeesDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(LateFees).Name);
            result.StatusCode=HttpStatusCode.OK;
            return result;
        }

        public async Task<GetLateFeesResult> GetAsync(int id)
        {
            var result = new GetLateFeesResult();
            var lateFee = await _lateFeesRepository.GetByIdAsync(id);
            if (lateFee==null)
                return Helper.Helper.CreateErrorResult<GetLateFeesResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("late fees"));
            var lateFeeDto = _mapper.Map<GetLateFeesDto>(lateFee);
            result.LateFee = lateFeeDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(LateFees).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<LateFeesResult> UpdateAsync(int id, LateFeesDto lateFeeDto)
        {
            var result = new LateFeesResult();
            var lateFee = await _lateFeesRepository.GetByIdAsync(id);
            if (lateFee == null)
                return Helper.Helper.CreateErrorResult<LateFeesResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("late fees"));

            _mapper.Map(lateFeeDto, lateFee);
            _changeLogService.SetUpdateChangeLogInfo(lateFee);
            await _lateFeesRepository.UpdateAsync(lateFee);
            result.LateFees = lateFeeDto;
            result.SuccessMessage= MessageEnum.Updated(typeof(LateFees).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
    }
}
