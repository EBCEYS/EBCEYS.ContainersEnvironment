using HealthChecks.UI.Core;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EBCEYS.ContainersEnvironment.HealthChecks.Models
{
    internal partial class TrimmedHealthReport(Dictionary<string, TrimmedHealthReportEntry> entries, TimeSpan totalDuration)
    {
        public UIHealthStatus Status { get; set; }
        public TimeSpan TotalDuration { get; set; } = totalDuration;
        public Dictionary<string, TrimmedHealthReportEntry> Entries { get; } = entries ?? [];

        public static TrimmedHealthReport CreateFrom(HealthReport report, Func<Exception, string>? exceptionMessage = null)
        {
            TrimmedHealthReport uiReport = new([], report.TotalDuration)
            {
                Status = (UIHealthStatus)report.Status,
            };

            foreach (KeyValuePair<string, HealthReportEntry> item in report.Entries)
            {
                TrimmedHealthReportEntry entry = TrimmedHealthReportEntry.CreateFrom(item.Value, exceptionMessage);

                uiReport.Entries.Add(item.Key, entry);
            }

            return uiReport;
        }
    }
}
