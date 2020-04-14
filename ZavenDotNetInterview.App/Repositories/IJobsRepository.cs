using System.Collections.Generic;
using System.Threading.Tasks;
using ZavenDotNetInterview.App.Models;

namespace ZavenDotNetInterview.App.Repositories
{
    public interface IJobsRepository
    {
         Task<List<Job>> GetAllJobs();
         Task<Job> GetJob(string name);
    }
}