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
    public class NationalityService(IRepository<Nationality> _NationalityReposatory, IMapper _mapper , IChangeLogService _changeLogService) : INationalityService
    {
        public async Task<NationalityResult> CreateAsync(NationalityDto nationalityDto)
        {
            var result = new NationalityResult();
            if (_NationalityReposatory.Find(n => n.Name.ToLower() == nationalityDto.Name.ToLower()) != null)
                return Helper.Helper.CreateErrorResult<NationalityResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("Nationality"));

            var nationality = _mapper.Map<Nationality>(nationalityDto);
            _changeLogService.SetCreateChangeLogInfo(nationality);
          await _NationalityReposatory.AddAsync(nationality);
            result.Nationality = nationalityDto;
            result.SuccessMessage = MessageEnum.Created(typeof(Nationality).Name);
            result.StatusCode = HttpStatusCode.Created;
            return result;
        }
        public async Task<NationalityResult> DeleteAsync(int id)
        {
            var result = new NationalityResult();
            var nationality = await _NationalityReposatory.GetByIdAsync(id);
            if (nationality == null)
                return Helper.Helper.CreateErrorResult<NationalityResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Nationality"));
            if (nationality.IsDeleted == true)
                return Helper.Helper.CreateErrorResult<NationalityResult>(HttpStatusCode.BadRequest, "Nationality Already Deleted");

            nationality.IsDeleted = true;
            _changeLogService.SetDeleteChangeLogInfo(nationality);
            await _NationalityReposatory.UpdateAsync(nationality);
            result.SuccessMessage = MessageEnum.Deleted(typeof(Nationality).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetNationalityResult> GetAllAsync()
        {
            var result = new GetNationalityResult();
            var nationality = await _NationalityReposatory.GetAllAsync();
            if(!nationality.Any())
                return Helper.Helper.CreateErrorResult<GetNationalityResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundAny("nationality"));
            var nationalityDto = _mapper.Map<List<GetNationalityDto>>(nationality);
            result.Nationalities = nationalityDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(GetNationalityResult).Name);
            return result;
        }

        public async Task<GetNationalityResult> GetAsync(int id)
        {
            var result = new GetNationalityResult();
            var nationality = await _NationalityReposatory.GetByIdAsync(id);
            if (nationality == null)
                return Helper.Helper.CreateErrorResult<GetNationalityResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Nationality"));
            var nationalityDto = _mapper.Map<GetNationalityDto>(nationality);
            result.Nationality = nationalityDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Nationality).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<NationalityResult> UpdateAsync(int id , NationalityDto nationalityDto)
        {
            var result = new NationalityResult();
            var nationality = await _NationalityReposatory.GetByIdAsync(id);
            if (nationality == null)
                return Helper.Helper.CreateErrorResult<NationalityResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("nationality"));
            var isDuplicateName = _NationalityReposatory.Find(n => n.Name.ToLower() == nationalityDto.Name.ToLower() && n.Id != id);
            if (isDuplicateName != null)
                return Helper.Helper.CreateErrorResult<NationalityResult>(HttpStatusCode.Conflict, ErrorEnum.Existed("nationality"));
            _mapper.Map(nationalityDto ,nationality);
            _changeLogService.SetUpdateChangeLogInfo(nationality);
            await _NationalityReposatory.UpdateAsync(nationality);
            result.Nationality = nationalityDto;
            result.SuccessMessage = MessageEnum.Updated(typeof(Nationality).Name);
            return result;

        }
    }
}
