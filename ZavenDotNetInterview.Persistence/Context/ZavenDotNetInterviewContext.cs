using System.Data.Entity;
using ZavenDotNetInterview.Core.Models;

namespace ZavenDotNetInterview.Persistence.Context
{
    public class ZavenDotNetInterviewContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Log> Logs { get; set; }

        public ZavenDotNetInterviewContext() : base("name=ZavenDotNetInterview")
        {
        }
    }
}