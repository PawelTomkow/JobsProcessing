using System;
using ZavenDotNetInterview.Core.Models;

namespace ZavenDotNetInterview.Infrastructure.DTOs
{
    public class JobDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime? DoAfter { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public DateTime CreationTime { get; set; }
        public int TryCounter { get; set; }
    }
}