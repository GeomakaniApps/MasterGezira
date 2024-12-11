using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IQualificationService 
    {
        Task<QualificationResult> CreateAsync(QualificationDto qualificationDto);
        Task<QualificationResult> UpdateAsync(int id ,QualificationDto qualificationDto);
        Task<QualificationResult> DeleteAsync(int id);
        Task<GetQualificationResult> GetAllAsync();
        Task<GetQualificationResult> GetAsync(int id);
    }
}
