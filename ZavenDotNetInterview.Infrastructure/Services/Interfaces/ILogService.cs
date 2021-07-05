using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZavenDotNetInterview.Core.Models;

namespace ZavenDotNetInterview.Infrastructure.Services.Interfaces
{
    public interface ILogService
    {
        Task LogUpdateStatus(Job job);
        Task LogAddJob(Job job);
        Task<List<Log>> GetLogsJob(Guid jobId);
        Task<List<Log>> GetLogsJobDescending(Guid jobId);
    }
}