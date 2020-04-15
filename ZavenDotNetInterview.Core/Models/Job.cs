using System;
using System.Collections.Generic;
using System.Data;

namespace ZavenDotNetInterview.Core.Models
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public JobStatus Status { get; set; }
        public DateTime? DoAfter { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public DateTime CreationTime { get; set; }
        public virtual List<Log> Logs { get; set; }
    }

    public enum JobStatus
    {
        Failed = -1,
        New = 0,
        InProgress = 1,
        Done = 2
    }
}