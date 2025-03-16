using HealthChecks.UI.Core;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EBCEYS.ContainersEnvironment.HealthChecks.Models
{
    internal partial class TrimmedHealthReportEntry
    {
        public IReadOnlyDictionary<string, object> Data { get; set; } = null!;
        public string? Description { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Exception { get; set; }
        public UIHealthStatus Status { get; set; }
        public IEnumerable<string>? Tags { get; set; }
        public static TrimmedHealthReportEntry CreateFrom(HealthReportEntry entry, Func<Exception, string>? exceptionMessage = null)
        {
            TrimmedHealthReportEntry res = new()
            {
                Data = entry.Data,
                Description = entry.Description,
                Duration = entry.Duration,
                Status = (UIHealthStatus)entry.Status
            };
            if (entry.Exception != null)
            {
                string? message = exceptionMessage == null ? entry.Exception?.Message : exceptionMessage(entry.Exception);

                res.Exception = message;
                res.Description = entry.Description ?? message;
            }

            res.Tags = entry.Tags;
            return res;
        }
    }
}
