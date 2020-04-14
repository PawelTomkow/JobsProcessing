using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZavenDotNetInterview.Core.Models;

namespace ZavenDotNetInterview.Core.Repositories
{
    public interface ILogsRepository
    {
        Task<List<Log>> GetJobLogs(Guid jobId);
        Task Add(Log log);
    }
}