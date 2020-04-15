using System.Collections.Generic;
using ZavenDotNetInterview.Core.Models;
using ZavenDotNetInterview.Infrastructure.DTOs;

namespace ZavenDotNetInterview.App.ViewModels.Jobs
{
    public class DetailsViewModel
    {
        public JobDto Job { get; set; }
        public List<Log> Logs { get; set; }
    }
}