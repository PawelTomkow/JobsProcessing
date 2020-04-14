using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ZavenDotNetInterview.Core.Models;
using ZavenDotNetInterview.Core.Repositories;
using ZavenDotNetInterview.Persistence.Context;

namespace ZavenDotNetInterview.Infrastructure.Repositories
{
    public class JobsRepository : IJobsRepository
    {
        private readonly ZavenDotNetInterviewContext _ctx;

        public JobsRepository(ZavenDotNetInterviewContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Job>> GetAllJobs()
        {
            return await _ctx.Jobs.ToListAsync();
        }

        public async Task<Job> GetJob(Guid id)
        {
            var result = await _ctx.Jobs.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            
            return result ?? new Job()
            {
                Name = string.Empty
            };
        }

        public async Task<List<Job>> GetStopedAndNotStartedJobs()
        {
            return await _ctx.Jobs
                .Where(job => job.Status == JobStatus.New || job.Status == JobStatus.Failed)
                .ToListAsync();
        }

        public async Task<Job> GetJob(string name)
        {
            var result = await _ctx.Jobs.Where(x => x.Name.Equals(name)).FirstOrDefaultAsync();
            
            return result ?? new Job()
            {
                Name = string.Empty
            };
        }

        public async Task UpdateJob(Job job)
        {
            var ctxJob = await _ctx.Jobs.FindAsync(job.Id);
            if (ctxJob != null)
            {
                ctxJob.Status = job.Status;
                await _ctx.SaveChangesAsync();
            }
        }
    }
}