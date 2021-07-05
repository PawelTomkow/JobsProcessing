using System.Collections.Generic;
using System.Threading.Tasks;
using ZavenDotNetInterview.Core.Models;

namespace ZavenDotNetInterview.Infrastructure.Services.Interfaces
{
    public interface IJobProcessorService
    {
        Task ProcessJobs();
    }
}