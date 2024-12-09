using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICityService
    {
        Task<GetCityResult> GetAllAsync();
        Task<GetCityResult> GetAsync(int id);
        Task<CityResult> CreateAsync(CityDto cityDto);
        Task<CityResult> UpdateAsync(int id, CityDto cityDto);
        Task<CityResult> DeleteAsync(int id);
    }
}
