using System.Collections.Generic;
using System.Threading.Tasks;
using ZavenDotNetInterview.App.Models;

namespace ZavenDotNetInterview.App.Services
{
    public interface IJobProcessorService
    {
        Task ProcessJobs();
        Task<List<Job>> GetJobs();
        Task<bool> DoesNameExist(string name);
    }
}