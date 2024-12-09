using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITransformationService
    {
        Task<GetTransformationResult> GetAllAsync();
        Task<GetTransformationResult> GetAsync(int id);
        Task<TransformationResult> CreateAsync(TransformationDto transformationDto);
        Task<TransformationResult> UpdateAsync(int id,TransformationDto transformationDto);
        Task<TransformationResult> DeleteAsync(int id);
    }
}
