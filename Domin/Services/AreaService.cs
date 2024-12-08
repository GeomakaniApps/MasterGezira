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
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AreaService(IRepository<Area> _areaRepository,IMapper _mapper) : IAreaService
    {
        public async Task<AreaResult> CreateAsync(AreaDto areaDto)
        {
            var result=new AreaResult();
            if(_areaRepository.Find(n=>n.Name.ToLower()==areaDto.Name.ToLower())!=null)
                return Helper.Helper.CreateErrorResult<AreaResult>(HttpStatusCode.BadRequest,ErrorEnum.Existed("Area"));
            Area area =_mapper.Map<Area>(areaDto);
           await _areaRepository.AddAsync(area);
           result.Area = areaDto;
           result.SuccessMessage = MessageEnum.Created(typeof(Area).Name);
           result.StatusCode = HttpStatusCode.Created;
           return result;
        }

        public async Task<AreaResult> DeleteAsync(int id)
        {
            var result = new AreaResult();
            var area = await _areaRepository.GetByIdAsync(id);
            if (area == null)
                return Helper.Helper.CreateErrorResult<AreaResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Area"));
            await _areaRepository.DeleteAsync(area);
            result.SuccessMessage=MessageEnum.Deleted(typeof(Area).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetAreaResult> GetAllAsync()
        {
            var result=new GetAreaResult();
            var areas=await _areaRepository.GetAllAsync();
            if(!areas.Any())
                return Helper.Helper.CreateErrorResult<GetAreaResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Area"));
            var areasDto = _mapper.Map<List<GetAreaDto>>(areas);
            result.Areas = areasDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Area).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetAreaResult> GetAsync(int id)
        {
            var result = new GetAreaResult();
            var area = await _areaRepository.GetByIdAsync(id);
            if (area == null)
                return Helper.Helper.CreateErrorResult<GetAreaResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Area"));
            var areaDto= _mapper.Map<GetAreaDto>(area);
            result.Area = areaDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Area).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<AreaResult> UpdateAsync(int id, AreaDto areaDto)
        {
            var result = new AreaResult();
            var area = await _areaRepository.GetByIdAsync(id);
            if (area == null)
                return Helper.Helper.CreateErrorResult<AreaResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Area"));
           _mapper.Map(areaDto, area);
           await _areaRepository.UpdateAsync(area);
           result.Area = areaDto;
           result.SuccessMessage = MessageEnum.Updated(typeof(Area).Name);
           result.StatusCode = HttpStatusCode.OK;
           return result;
        }
    }
}
