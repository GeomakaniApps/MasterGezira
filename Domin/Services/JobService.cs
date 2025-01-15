using AutoMapper;
using Core.Infrastruture.RepositoryPattern.Repository;
using DataLayer.Models;
using Domain.DTOs;
using Domain.Helper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class JobService(IRepository<Job> _jobRepository,IMapper _mapper ,IChangeLogService _changeLogService , IHistoryLogService _historyLogService):IJobService
    {
        public async Task<JobResult> CreateAsync(JobDto jobDto)
        {
            var result = new JobResult();
            if (_jobRepository.Find(n => n.Name.ToLower() == jobDto.Name.ToLower()) != null)
                return Helper.Helper.CreateErrorResult<JobResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("Job"));
            Job job = _mapper.Map<Job>(jobDto);
            _changeLogService.SetCreateChangeLogInfo(job);
            await _jobRepository.AddAsync(job);
            result.Job = jobDto;
            result.SuccessMessage = MessageEnum.Created(typeof(Area).Name);
            result.StatusCode = HttpStatusCode.Created;
            return result;
        }

        public async Task<JobResult> DeleteAsync(int id)
        {
            var result = new JobResult();
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null)
                return Helper.Helper.CreateErrorResult<JobResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Job"));
            if (job.IsDeleted == true)
                return Helper.Helper.CreateErrorResult<JobResult>(HttpStatusCode.BadRequest, "Job Already Deleted");

            job.IsDeleted = true;
            _changeLogService.SetDeleteChangeLogInfo(job);
            await _jobRepository.UpdateAsync(job);
            result.SuccessMessage = MessageEnum.Deleted(typeof(Job).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetJobResult> GetAllAsync()
        {
            var result = new GetJobResult();
            var jobs = await _jobRepository.GetAllAsync();
            if (!jobs.Any())
                return Helper.Helper.CreateErrorResult<GetJobResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Job"));
            var jobsDto = _mapper.Map<List<GetJobDto>>(jobs);
            result.Jobs = jobsDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Job).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetJobResult> GetAsync(int id)
        {
            var result = new GetJobResult();
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null)
                return Helper.Helper.CreateErrorResult<GetJobResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Job"));
            var jobDto = _mapper.Map<GetJobDto>(job);
            result.Job = jobDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(Job).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<JobResult> UpdateAsync(int id, JobDto jobDto)
        {
            var result = new JobResult();
            var job = await _jobRepository.GetByIdAsync(id);
            var oldJob = new Job();
            _mapper.Map(job, oldJob);
            if (job == null)
                return Helper.Helper.CreateErrorResult<JobResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Job"));
            _mapper.Map(jobDto, job);
            _changeLogService.SetUpdateChangeLogInfo(job);
            await _jobRepository.UpdateAsync(job);
            await _historyLogService.CompareAndLogJobChanges(job , oldJob , (int)job.UpdateBy);
            result.Job = jobDto;
            result.SuccessMessage = MessageEnum.Updated(typeof(Job).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
    }
}
