using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILateFeesService
    {
        Task<GetLateFeesResult> GetAllAsync();
        Task<GetLateFeesResult> GetAsync(int id);
        Task<LateFeesResult> CreateAsync(LateFeesDto lateFeesDto);
        Task<LateFeesResult> UpdateAsync(int id, LateFeesDto lateFeeDto);
        Task<LateFeesResult> DeleteAsync(int id);
    }
}
