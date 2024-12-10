using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISectionService
    {
        Task<GetSectionResult> GetAllAsync();
        Task<GetSectionResult> GetAsync(int id);
        Task<SectionResult> CreateAsync(SectionDto sectionDto);
        Task<SectionResult> UpdateAsync(int id, SectionDto sectionDto);
        Task<SectionResult> DeleteAsync(int id);
    }
}
