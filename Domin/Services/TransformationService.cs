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
    public class TransformationService(IRepository<Transformation> _transformationRepository,IMapper _mapper ,IChangeLogService _changeLogService) : ITransformationService
    {
        public async Task<TransformationResult> CreateAsync(TransformationDto transformationDto)
        {
            var result= new TransformationResult();
            if (_transformationRepository.Find(n=>n.Name.ToLower()==transformationDto.Name.ToLower())!=null)
                return Helper.Helper.CreateErrorResult<TransformationResult>(HttpStatusCode.BadRequest,ErrorEnum.Existed("transformation"));
            var transformation=_mapper.Map<Transformation>(transformationDto);
            _changeLogService.SetCreateChangeLogInfo(transformation);
            await _transformationRepository.AddAsync(transformation);
            result.Transformation=transformationDto;
            result.SuccessMessage = MessageEnum.Created(typeof(Transformation).Name);
            result.StatusCode=HttpStatusCode.Created;
            return result;
        }

        public async Task<TransformationResult> DeleteAsync(int id)
        {
            var result = new TransformationResult();
            var transformation = await _transformationRepository.GetByIdAsync(id);
            if (transformation == null)
                return Helper.Helper.CreateErrorResult<TransformationResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("transformation"));
            if (transformation.IsDeleted == true)
                return Helper.Helper.CreateErrorResult<TransformationResult>(HttpStatusCode.BadRequest, "Transformation Already Deleted");

            transformation.IsDeleted = true;
            _changeLogService.SetDeleteChangeLogInfo(transformation);
            await _transformationRepository.UpdateAsync(transformation);
           result.SuccessMessage = MessageEnum.Deleted(typeof(Transformation).Name);
           return result;
        }

        public async Task<GetTransformationResult> GetAllAsync()
        {
            var result = new GetTransformationResult();
            var transformations = await _transformationRepository.GetAllAsync();
            if (!transformations.Any())
                return Helper.Helper.CreateErrorResult<GetTransformationResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundAny("transformation"));
            var transformationsDto = _mapper.Map<List<GetTransformationDto>>(transformations);
            result.Transformations = transformationsDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Transformation).Name);
            return result;
        }

        public async Task<GetTransformationResult> GetAsync(int id)
        {
            var result=new GetTransformationResult();
            var transformation = await _transformationRepository.GetByIdAsync(id);
            if (transformation == null)
                return Helper.Helper.CreateErrorResult<GetTransformationResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("transformation"));
            var transformationDto=_mapper.Map<GetTransformationDto>(transformation);
            result.Transformation = transformationDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Transformation).Name);
            return result;
        }

        public async Task<TransformationResult> UpdateAsync(int id, TransformationDto transformationDto)
        {
            var result = new TransformationResult();
            var transformation = await _transformationRepository.GetByIdAsync(id);
            if (transformation == null)
                return Helper.Helper.CreateErrorResult<TransformationResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("transformation"));
            var isDuplicateName = _transformationRepository.Find(t => t.Name.ToLower() == transformationDto.Name.ToLower() && t.Id != id);
            if (isDuplicateName!=null)
                return Helper.Helper.CreateErrorResult<TransformationResult>(HttpStatusCode.Conflict,ErrorEnum.Existed("transformation"));
            _mapper.Map(transformationDto, transformation);
            _changeLogService.SetUpdateChangeLogInfo(transformation);
            await _transformationRepository.UpdateAsync(transformation);
            result.Transformation = transformationDto;
            result.SuccessMessage=MessageEnum.Updated(typeof(Transformation).Name);
            return result;
        }
    }
}
