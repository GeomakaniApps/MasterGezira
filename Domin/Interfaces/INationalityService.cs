using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface INationalityService
    {
        Task<NationalityResult> CreateAsync(NationalityDto nationalityDto);
        Task<NationalityResult> UpdateAsync(int id ,NationalityDto nationalityDto);
        Task<NationalityResult> DeleteAsync(int id);
        Task<GetNationalityResult> GetAllAsync();
        Task<GetNationalityResult> GetAsync(int id);
    }
}
