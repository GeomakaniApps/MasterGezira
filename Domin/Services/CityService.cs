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
    public class CityService(IRepository<City> _cityReposatory, IMapper _mapper , IChangeLogService _changeLogService , IHistoryLogService _historyLogService) : ICityService
    {
        public async Task<CityResult> CreateAsync(CityDto cityDto)
        {
            var result = new CityResult();
            var NameCity = _cityReposatory.Find(n => n.Name.ToLower() == cityDto.Name.ToLower());
            if (NameCity != null)
                return Helper.Helper.CreateErrorResult<CityResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("City"));
            City city = _mapper.Map<City>(cityDto);
            _changeLogService.SetCreateChangeLogInfo(city);
            await _cityReposatory.AddAsync(city);
            result.City = cityDto;
            result.SuccessMessage = MessageEnum.Created(typeof(City).Name);
            result.StatusCode = HttpStatusCode.Created;
            return result;

        }

        public async Task<CityResult> DeleteAsync(int id)
        {
            var result = new CityResult();
            var city = await _cityReposatory.GetByIdAsync(id);
            if (city == null)
                return Helper.Helper.CreateErrorResult<CityResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("City"));
            if (city.IsDeleted == true)
                return Helper.Helper.CreateErrorResult<CityResult>(HttpStatusCode.BadRequest, "City Already Deleted");

            city.IsDeleted = true;
            _changeLogService.SetDeleteChangeLogInfo(city);
            await _cityReposatory.UpdateAsync(city);
            result.SuccessMessage = MessageEnum.Deleted(typeof(City).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;

        }
        public async Task<GetCityResult> GetAllAsync()
        {
            var result = new GetCityResult();
            var cities = await _cityReposatory.GetAllAsync();
            if (!cities.Any())
                return Helper.Helper.CreateErrorResult<GetCityResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("City"));
            var citiesDto = _mapper.Map<List<GetCityDto>>(cities);
            result.Cities = citiesDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(City).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetCityResult> GetAsync(int id)
        {
            var result = new GetCityResult();
            var city = await _cityReposatory.GetByIdAsync(id);
            if (city == null)
                return Helper.Helper.CreateErrorResult<GetCityResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("City"));
            var cityDto = _mapper.Map<GetCityDto>(city);
            result.City = cityDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(City).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<CityResult> UpdateAsync(int id, CityDto cityDto)
        {
            var result = new CityResult();
            var city = await _cityReposatory.GetByIdAsync(id);
            var oldCity = new City();
            _mapper.Map(city, oldCity);
            if (city == null)
                return Helper.Helper.CreateErrorResult<CityResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("City"));
            _mapper.Map(cityDto, city);
            _changeLogService.SetUpdateChangeLogInfo(city);
            await _cityReposatory.UpdateAsync(city);
             await _historyLogService.CompareAndLogCiryChanges(city, oldCity, (int)city.UpdateBy);
            result.City = cityDto;
            result.SuccessMessage = MessageEnum.Updated(typeof(City).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
    }
}