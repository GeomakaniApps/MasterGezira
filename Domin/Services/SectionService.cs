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
    public class SectionService(IRepository<Section> _SectionRepository, IMapper _mapper,IRepository<MemberType> _memberTypeRepository) : ISectionService
    {
        public async Task<SectionResult> CreateAsync(SectionDto SectionDto)
        {
            var result = new SectionResult();
            if (_SectionRepository.Find(n => n.Name.ToLower() == SectionDto.Name.ToLower()) != null)
                return Helper.Helper.CreateErrorResult<SectionResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("Section"));
            var memberType = await _memberTypeRepository.GetByIdAsync(SectionDto.MemberTypeId);
            if (memberType == null)
                return Helper.Helper.CreateErrorResult<SectionResult>(HttpStatusCode.BadRequest, "Didn't find the member type you passed it");
            SectionDto.Price = SectionDto.Price - ((SectionDto.Price * SectionDto.Discount) / 100);
            Section section = _mapper.Map<Section>(SectionDto);
            section.PriceWithoutTax = (section.Price * 100) / 114;
            section.Tax = section.Price - section.PriceWithoutTax;
            await _SectionRepository.AddAsync(section);
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
            if (Section.IsDeleted == true)
                return Helper.Helper.CreateErrorResult<SectionResult>(HttpStatusCode.BadRequest, "Section already Deleted");
            Section.IsDeleted = true;
            await _SectionRepository.UpdateAsync(Section);
            result.SuccessMessage = MessageEnum.Deleted(typeof(Section).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetSectionResult> FindAllIsDeleteFalseAsync()
        {
            var result = new GetSectionResult();
            var SectionCondition = (Expression<Func<Section, bool>>)(mt => mt.IsDeleted == false);
            var Sections = await _SectionRepository.FindAllAsync(SectionCondition);
            if (!Sections.Any())
                return Helper.Helper.CreateErrorResult<GetSectionResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Section"));
            var SectionsDto = _mapper.Map<List<GetSectionDto>>(Sections);
            result.Sections = SectionsDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Section).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
          public async Task<GetSectionResult> GetAllAsync()
        {
            var result = new GetSectionResult();
            var Sections = await _SectionRepository.GetAllAsync(includeProperties:"MemberType");
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
            var section = await _SectionRepository.GetByIdAsync(id);
            if (section == null)
                return Helper.Helper.CreateErrorResult<GetSectionResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Section"));
            var SectionDto = _mapper.Map<GetSectionDto>(section);
            result.Section = SectionDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Section).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<SectionResult> UpdateAsync(int id, SectionDto SectionDto)
        {
            var result = new SectionResult();
            var section = await _SectionRepository.GetByIdAsync(id);
            if (section == null)
                return Helper.Helper.CreateErrorResult<SectionResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Section"));
            var isDuplacateName = await _SectionRepository.FindAsync(n => n.Name.ToLower() == SectionDto.Name.ToLower() && n.Id != id);
            if (isDuplacateName != null)
                return Helper.Helper.CreateErrorResult<SectionResult>(HttpStatusCode.Conflict, ErrorEnum.Existed("Section"));
            var memberType = await _memberTypeRepository.GetByIdAsync(SectionDto.MemberTypeId);
            if (memberType == null)
                return Helper.Helper.CreateErrorResult<SectionResult>(HttpStatusCode.BadRequest, "Didn't find the member type you passed it");
            SectionDto.Price = SectionDto.Price - ((SectionDto.Price * SectionDto.Discount) / 100);
            _mapper.Map(SectionDto, section);
            section.PriceWithoutTax = (section.Price * 100) / 114;
            section.Tax = section.Price - section.PriceWithoutTax;
            await _SectionRepository.UpdateAsync(section);
            result.Section = SectionDto;
            result.SuccessMessage = MessageEnum.Updated(typeof(Section).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
    }
}
