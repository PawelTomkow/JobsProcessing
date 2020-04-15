using System.Collections.Generic;
using ZavenDotNetInterview.Core.Models;

namespace ZavenDotNetInterview.App.ViewModels.Jobs
{
    public class DetailsViewModel
    {
        public Job Job { get; set; }
        public List<Log> Logs { get; set; }
    }
}