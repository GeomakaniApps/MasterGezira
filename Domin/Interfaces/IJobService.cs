using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IJobService
    {
        Task<GetJobResult> GetAllAsync();
        Task<GetJobResult> GetAsync(int id);
        Task<JobResult> CreateAsync(JobDto jobDto);
        Task<JobResult> UpdateAsync(int id, JobDto jobDto);
        Task<JobResult> DeleteAsync(int id);
    }
}
