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
        private readonly ILogService _logService;

        public JobProcessorService(JobsRepository repository, ILogService logService)
        {
            _repository = repository;
            _logService = logService;
        }

        private async Task StartProcessJob(Job jobToProcess)
        {
            await jobToProcess.ChangeStatus(JobStatus.InProgress, _logService);
            var result = await ProcessJob(jobToProcess).ConfigureAwait(false);

            var newStatus = result ? JobStatus.Done : JobStatus.Failed;
            await jobToProcess.ChangeStatus(newStatus, _logService);

            await _repository.UpdateJob(jobToProcess);
        }
        
        public async Task ProcessJobs()
        {
            var jobsToProcess = await _repository.GetStopedAndNotStartedJobs();

            foreach (var job in jobsToProcess)
            {
                await StartProcessJob(job);
            }
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
    }
}