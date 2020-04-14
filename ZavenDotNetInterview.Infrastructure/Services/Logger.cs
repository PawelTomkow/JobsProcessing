using System;
using System.Threading.Tasks;
using ZavenDotNetInterview.Core.Models;
using ZavenDotNetInterview.Core.Repositories;
using ZavenDotNetInterview.Infrastructure.Services.Interfaces;

namespace ZavenDotNetInterview.Infrastructure.Services
{
    public class Logger : ILogger
    {
        private readonly ILogsRepository _context;

        public Logger(ILogsRepository context)
        {
            _context = context;
        }
        
        public async Task LogUpdateStatus(Job job)
        {
            var log = GenerateUpdateStatus(job);
            await _context.Add(log);
        }

        public async Task LogAddJob(Job job)
        {
            var log = GenerateNewJob(job);
            await _context.Add(log);
        }
        
        private static Log GenerateUpdateStatus(Job job) => new Log
        {
            Id = Guid.NewGuid(),
            Description = "Update status",
            Job = job,
            CreatedAt = DateTime.Now,
            JobId = job.Id
        };
        
        private static Log GenerateNewJob(Job job) => new Log
        {
            Id = Guid.NewGuid(),
            Description = "Create Log",
            Job = job,
            CreatedAt = DateTime.Now,
            JobId = job.Id
        };
    }
}