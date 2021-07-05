using System.Threading;

namespace ZavenDotNetInterview.Core.Models
{
    public enum JobStatus
    {
        Failed = -1,
        New = 0,
        InProgress = 1,
        Done = 2,
        Closed = 3
    }

    public static class JobStatusExtension
    {
        public static string ToHumanString(this JobStatus status)
        {
            switch (status)
            {
                case JobStatus.Failed:
                    return "Failed";
                case JobStatus.Closed:
                    return "Closed";
                case JobStatus.Done:
                    return "Done";
                case JobStatus.New:
                    return "New";
                case JobStatus.InProgress:
                    return "InProgess";
                default:
                    return "Unknown";
            }
        }
    }
}
