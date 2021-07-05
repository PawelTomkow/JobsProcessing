using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZavenDotNetInterview.Core.Models;

namespace ZavenDotNetInterview.Core.Repositories
{
    public interface IJobsRepository
    {
         IQueryable<Job> GetAllJobs();
         Task<Job> GetJob(string name);
         Task<Job> GetJob(Guid id);
         Task<List<Job>> GetStopedAndNotStartedJobs();
         Task UpdateJob(Job job);
         Task Add(Job job);
    }
}