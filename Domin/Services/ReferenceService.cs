﻿using AutoMapper; 
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
    public class ReferenceService(IRepository<Reference> _ReferenceRepository , IMapper _mapper) : IReferenceService
    {
        public async Task<ReferenceResult> CreateAsync(ReferenceDto referenceDto)
        {
            var result = new ReferenceResult();
            if (_ReferenceRepository.Find(n => n.Name.ToLower() == referenceDto.Name.ToLower()) != null)
                return Helper.Helper.CreateErrorResult<ReferenceResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("Reference"));
            if (referenceDto.Price <= 0)
                 return Helper.Helper.CreateErrorResult<ReferenceResult>(HttpStatusCode.BadRequest, "Price is not valid");
     
            Reference Reference = _mapper.Map<Reference>(referenceDto);
            await _ReferenceRepository.AddAsync(Reference);
            result.Reference = referenceDto;
            result.SuccessMessage = MessageEnum.Created(typeof(Reference).Name);
            result.StatusCode = HttpStatusCode.Created;
            return result;
        }

        public async Task<ReferenceResult> DeleteAsync(int id)
        {
            var result = new ReferenceResult();
            var Reference = await _ReferenceRepository.GetByIdAsync(id);
            if (Reference == null)
                return Helper.Helper.CreateErrorResult<ReferenceResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Reference"));
            await _ReferenceRepository.DeleteAsync(Reference);
            result.SuccessMessage = MessageEnum.Deleted(typeof(Reference).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetReferenceResult> GetAllAsync()
        {
            var result = new GetReferenceResult();
            var Reference = await _ReferenceRepository.GetAllAsync();
            if (!Reference.Any())
                return Helper.Helper.CreateErrorResult<GetReferenceResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Reference"));
            var ReferenceDto = _mapper.Map<List<GetReferenceDto>>(Reference);
            result.References = ReferenceDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Reference).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetReferenceResult> GetAsync(int id)
        {
            var result = new GetReferenceResult();
            var Reference = await _ReferenceRepository.GetByIdAsync(id);
            if (Reference == null)
                return Helper.Helper.CreateErrorResult<GetReferenceResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Reference"));
            var referenceDto = _mapper.Map<GetReferenceDto>(Reference);
            result.Reference = referenceDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Reference).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<ReferenceResult> UpdateAsync(int id, ReferenceDto referenceDto)
        {
            var result = new ReferenceResult();
            var Reference = await _ReferenceRepository.GetByIdAsync(id);
            if (Reference == null)
                return Helper.Helper.CreateErrorResult<ReferenceResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Reference"));
            var isDuplacateName = await _ReferenceRepository.FindAsync(n => n.Name.ToLower() == referenceDto.Name.ToLower() && n.id != id);
            if (isDuplacateName != null)
                return Helper.Helper.CreateErrorResult<ReferenceResult>(HttpStatusCode.Conflict, ErrorEnum.Existed("Reference"));
            if (referenceDto.Price <= 0)
                return Helper.Helper.CreateErrorResult<ReferenceResult>(HttpStatusCode.BadRequest, "price is not valid");
        
            _mapper.Map(referenceDto, Reference);          
            await _ReferenceRepository.UpdateAsync(Reference);
            result.Reference = referenceDto;
            result.SuccessMessage = MessageEnum.Updated(typeof(Reference).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
    }
}