using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReferenceService 
    {
        Task<GetReferenceResult> GetAllAsync();
        Task<GetReferenceResult> GetAsync(int id);
        Task<ReferenceResult> CreateAsync(ReferenceDto referenceDto);
        Task<ReferenceResult> UpdateAsync(int id ,ReferenceDto referenceDto);
        Task<ReferenceResult> DeleteAsync(int id);
    }
}
