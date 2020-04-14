
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ZavenDotNetInterview.Persistence.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ZavenDotNetInterview.Persistence.Context.ZavenDotNetInterviewContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}