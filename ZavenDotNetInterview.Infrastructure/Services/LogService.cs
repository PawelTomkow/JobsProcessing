using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZavenDotNetInterview.Core.Models;
using ZavenDotNetInterview.Core.Repositories;
using ZavenDotNetInterview.Infrastructure.Services.Interfaces;

namespace ZavenDotNetInterview.Infrastructure.Services
{
    public class LogService : ILogService
    {
        private readonly ILogsRepository _repository;

        public LogService(ILogsRepository repository)
        {
            _repository = repository;
        }
        
        public async Task LogUpdateStatus(Job job)
        {
            var log = GenerateUpdateStatus(job);
            await _repository.Add(log);
        }

        public async Task LogAddJob(Job job)
        {
            var log = GenerateNewJob(job);
            await _repository.Add(log);
        }

        public async Task<List<Log>> GetLogsJob(Guid jobId)
        {
            return await _repository.GetJobLogs(jobId);
        }
        
        public async Task<List<Log>> GetLogsJobDescending(Guid jobId)
        {
            return (await _repository.GetJobLogs(jobId)).OrderByDescending(job => job.CreatedAt).ToList();
        }

        private static Log GenerateUpdateStatus(Job job) => new Log
        {
            Id = Guid.NewGuid(),
            Description = "Update status",
            Job = job,
            CreatedAt = DateTime.Now,
            JobId = job.Id
        };
        
        private static Log GenerateNewJob(Job job) => new Log
        {
            Id = Guid.NewGuid(),
            Description = "Create Log",
            Job = job,
            CreatedAt = DateTime.Now,
            JobId = job.Id
        };
    }
}