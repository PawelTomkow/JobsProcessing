using System.Threading.Tasks;
using ZavenDotNetInterview.Core.Models;

namespace ZavenDotNetInterview.Infrastructure.Services.Interfaces
{
    public interface ILogger
    {
        Task LogUpdateStatus(Job job);
        Task LogAddJob(Job job);
    }
}