using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZavenDotNetInterview.Core.Models;
using ZavenDotNetInterview.Core.Repositories;
using ZavenDotNetInterview.Infrastructure.Extensions;
using ZavenDotNetInterview.Infrastructure.Repositories;
using ZavenDotNetInterview.Infrastructure.Services.Interfaces;
using ZavenDotNetInterview.Persistence.Context;

namespace ZavenDotNetInterview.Infrastructure.Services
{
    public class JobProcessorService : IJobProcessorService
    {
        private readonly JobsRepository _repository;
        private readonly ILogger _logger;

        public JobProcessorService(JobsRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        private async Task StartProcessJob(Job jobToProcess)
        {
            await jobToProcess.ChangeStatus(JobStatus.InProgress, _logger);
            var result = await ProcessJob(jobToProcess).ConfigureAwait(false);

            var newStatus = result ? JobStatus.Done : JobStatus.Failed;
            await jobToProcess.ChangeStatus(newStatus, _logger);

            await _repository.UpdateJob(jobToProcess);
        }
        
        public async Task ProcessJobs()
        {
            var jobsToProcess = await _repository.GetStopedAndNotStartedJobs();

            jobsToProcess.ForEach(async job => await StartProcessJob(job));
        }

        private async Task<bool> ProcessJob(Job job)
        {
            Random rand = new Random();
            if (rand.Next(10) < 5)
            {
                await Task.Delay(2000);
                return false;
            }
            else
            {
                await Task.Delay(1000);
                return true;
            }
        }

        public async Task<List<Job>> GetJobs()
        {
            return await _repository.GetAllJobs();
        }

        public async Task<bool> DoesNameExist(string name)
        {
            var result = await _repository.GetJob(name);
            return string.IsNullOrWhiteSpace(result.Name);
        }
    }
}