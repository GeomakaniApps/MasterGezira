using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAreaService
    {
        Task<GetAreaResult> GetAllAsync();
        Task<GetAreaResult> GetAsync(int id);
        Task<AreaResult> CreateAsync(AreaDto areaDto);
        Task<AreaResult> UpdateAsync(int id,AreaDto areaDto);
        Task<AreaResult> DeleteAsync(int id);
    }
}
