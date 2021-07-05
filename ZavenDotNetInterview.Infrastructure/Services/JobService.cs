using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ZavenDotNetInterview.Core.Models;
using ZavenDotNetInterview.Core.Repositories;
using ZavenDotNetInterview.Infrastructure.DTOs;
using ZavenDotNetInterview.Infrastructure.Services.Interfaces;

namespace ZavenDotNetInterview.Infrastructure.Services
{
    public class JobService : IJobService
    {
        private readonly IJobsRepository _repository;
        private readonly IMapper _mapper;

        public JobService(IJobsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<List<JobDto>> GetAllJobs(bool orderByCreateDateAsc = false)
        {
            var result =  _repository.GetAllJobs();
            if (orderByCreateDateAsc)
            {
                result = result.OrderBy(job => job.CreationTime);
            }
            return _mapper.Map<List<JobDto>>(await result.ToListAsync());
        }

        public async Task<bool> DoesNameExist(string name)
        {
            var result = await _repository.GetJob(name);
            return string.IsNullOrWhiteSpace(result.Name);
        }

        public async Task<JobDto> GetJob(Guid id)
        {
            var result = await _repository.GetJob(id);
            return _mapper.Map<JobDto>(result);
        }

        public async Task AddJob(DateTime doAfter, string name)
        {
            var job = new Job
            {
                Id = Guid.NewGuid(),
                Status = JobStatus.New,
                CreationTime = DateTime.Now,
                TryCounter = 0,
                DoAfter = doAfter,
                Name = name
            };

            await _repository.Add(job);
        }
    }
}