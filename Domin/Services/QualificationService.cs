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
    public class QualificationService(IRepository<Qualification> _QualificationRepository, IMapper _mapper) : IQualificationService
    {
        public async Task<QualificationResult> CreateAsync(QualificationDto qualificationDto)
        {
            var result = new QualificationResult();
            if (_QualificationRepository.Find(n => n.Name.ToLower() == qualificationDto.Name.ToLower()) != null)
                return Helper.Helper.CreateErrorResult<QualificationResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("Qualification"));
            Qualification Qualification = _mapper.Map<Qualification>(qualificationDto);
            await _QualificationRepository.AddAsync(Qualification);
            result.Qualification = qualificationDto;
            result.SuccessMessage = MessageEnum.Created(typeof(Qualification).Name);
            result.StatusCode = HttpStatusCode.Created;
            return result;
        }

        public async Task<QualificationResult> DeleteAsync(int id)
        {
            var result = new QualificationResult();
            var Qualification = await _QualificationRepository.GetByIdAsync(id);
            if (Qualification == null)
                return Helper.Helper.CreateErrorResult<QualificationResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Qualification"));
            await _QualificationRepository.DeleteAsync(Qualification);
            result.SuccessMessage = MessageEnum.Deleted(typeof(Qualification).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetQualificationResult> GetAllAsync()
        {
            var result = new GetQualificationResult();
            var Qualification = await _QualificationRepository.GetAllAsync();
            if (!Qualification.Any())
                return Helper.Helper.CreateErrorResult<GetQualificationResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Qualification"));
            var QualificationDto = _mapper.Map<List<GetQualificationDto>>(Qualification);
            result.Qualifications = QualificationDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Qualification).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetQualificationResult> GetAsync(int id)
        {
            var result = new GetQualificationResult();
            var Qualification = await _QualificationRepository.GetByIdAsync(id);
            if (Qualification == null)
                return Helper.Helper.CreateErrorResult<GetQualificationResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Qualification"));
            var QualificationDto = _mapper.Map<GetQualificationDto>(Qualification);
            result.Qualification = QualificationDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Qualification).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<QualificationResult> UpdateAsync(int id , QualificationDto qualificationDto)
        {
            var result = new QualificationResult();
            var Qualification = await _QualificationRepository.GetByIdAsync(id);
            if (Qualification == null)
                return Helper.Helper.CreateErrorResult<QualificationResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Qualification"));
            var isDuplacateName = await _QualificationRepository.FindAsync(n => n.Name.ToLower() == qualificationDto.Name.ToLower() && n.id != id);
            if (isDuplacateName != null)
                return Helper.Helper.CreateErrorResult<QualificationResult>(HttpStatusCode.Conflict, ErrorEnum.Existed("Qualification"));
            _mapper.Map(qualificationDto, Qualification);
            await _QualificationRepository.UpdateAsync(Qualification);
            result.Qualification = qualificationDto;
            result.SuccessMessage = MessageEnum.Updated(typeof(Qualification).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
    }
}