using System;
using System.Collections.Generic;
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
        
        public async Task<List<JobDto>> GetJobs()
        {
            var result =  await _repository.GetAllJobs();
            return _mapper.Map<List<JobDto>>(result);
        }

        public async Task<bool> DoesNameExist(string name)
        {
            var result = await _repository.GetJob(name);
            return string.IsNullOrWhiteSpace(result.Name);
        }

        public async Task<Job> GetJob(Guid id)
        {
            return await _repository.GetJob(id);
        }
    }
}