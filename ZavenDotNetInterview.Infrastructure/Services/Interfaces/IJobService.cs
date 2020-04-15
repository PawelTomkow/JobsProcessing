using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZavenDotNetInterview.Core.Models;
using ZavenDotNetInterview.Infrastructure.DTOs;

namespace ZavenDotNetInterview.Infrastructure.Services.Interfaces
{
    public interface IJobService
    {
        Task<List<JobDto>> GetAllJobs(bool orderByCreateDateAsc = false);
        Task<bool> DoesNameExist(string name);
        Task<Job> GetJob(Guid id);
    }
}