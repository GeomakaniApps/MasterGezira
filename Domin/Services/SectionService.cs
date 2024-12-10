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
    public class SectionService(IRepository<Section> _SectionRepository, IMapper _mapper) : ISectionService
    {
        public async Task<SectionResult> CreateAsync(SectionDto SectionDto)
        {
            var result = new SectionResult();
            if (_SectionRepository.Find(n => n.Name.ToLower() == SectionDto.Name.ToLower()) != null)
                return Helper.Helper.CreateErrorResult<SectionResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("Section"));
            Section Section = _mapper.Map<Section>(SectionDto);
            await _SectionRepository.AddAsync(Section);
            result.Section = SectionDto;
            result.SuccessMessage = MessageEnum.Created(typeof(Section).Name);
            result.StatusCode = HttpStatusCode.Created;
            return result;
        }

        public async Task<SectionResult> DeleteAsync(int id)
        {
            var result = new SectionResult();
            var Section = await _SectionRepository.GetByIdAsync(id);
            if (Section == null)
                return Helper.Helper.CreateErrorResult<SectionResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Section"));
            await _SectionRepository.DeleteAsync(Section);
            result.SuccessMessage = MessageEnum.Deleted(typeof(Section).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetSectionResult> GetAllAsync()
        {
            var result = new GetSectionResult();
            var Sections = await _SectionRepository.GetAllAsync();
            if (!Sections.Any())
                return Helper.Helper.CreateErrorResult<GetSectionResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Section"));
            var SectionsDto = _mapper.Map<List<GetSectionDto>>(Sections);
            result.Sections = SectionsDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Section).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetSectionResult> GetAsync(int id)
        {
            var result = new GetSectionResult();
            var Section = await _SectionRepository.GetByIdAsync(id);
            if (Section == null)
                return Helper.Helper.CreateErrorResult<GetSectionResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Section"));
            var SectionDto = _mapper.Map<GetSectionDto>(Section);
            result.Section = SectionDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Section).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<SectionResult> UpdateAsync(int id, SectionDto SectionDto)
        {
            var result = new SectionResult();
            var Section = await _SectionRepository.GetByIdAsync(id);
            if (Section == null)
                return Helper.Helper.CreateErrorResult<SectionResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Section"));
            var isDuplacateName = await _SectionRepository.FindAsync(n => n.Name.ToLower() == SectionDto.Name.ToLower() && n.Id != id);
            if (isDuplacateName != null)
                return Helper.Helper.CreateErrorResult<SectionResult>(HttpStatusCode.Conflict, ErrorEnum.Existed("Section"));
            _mapper.Map(SectionDto, Section);
            await _SectionRepository.UpdateAsync(Section);
            result.Section = SectionDto;
            result.SuccessMessage = MessageEnum.Updated(typeof(Section).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
    }
}
