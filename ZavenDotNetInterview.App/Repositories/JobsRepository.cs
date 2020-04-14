using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.Models.Context;

namespace ZavenDotNetInterview.App.Repositories
{
    public class JobsRepository : IJobsRepository
    {
        private readonly ZavenDotNetInterviewContext _ctx;

        public JobsRepository(ZavenDotNetInterviewContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Job>> GetAllJobs()
        {
            return await _ctx.Jobs.ToListAsync();
        }
    }
}