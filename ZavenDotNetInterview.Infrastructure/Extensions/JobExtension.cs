using System.Threading.Tasks;
using ZavenDotNetInterview.Core.Models;
using ZavenDotNetInterview.Infrastructure.Services.Interfaces;

namespace ZavenDotNetInterview.Infrastructure.Extensions
{
    internal static class JobExtension
    {
        public static async Task ChangeStatus(this Job job, JobStatus newStatus, ILogService logService)
        {
            job.Status = newStatus;
            await logService.LogUpdateStatus(job);
        }
    }
}