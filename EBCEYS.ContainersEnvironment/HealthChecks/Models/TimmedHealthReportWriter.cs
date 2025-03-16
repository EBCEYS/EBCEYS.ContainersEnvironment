using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EBCEYS.ContainersEnvironment.HealthChecks.Models
{
    internal static class TimmedHealthReportWriter
    {
        private const string DEFAULT_CONTENT_TYPE = "application/json";

        private static readonly byte[] _emptyResponse = "{}"u8.ToArray();
        public static async Task WriteHealthCheckUIResponse(HttpContext httpContext, HealthReport report)
        {
            if (report != null)
            {
                httpContext.Response.ContentType = DEFAULT_CONTENT_TYPE;
                TrimmedHealthReport value = TrimmedHealthReport.CreateFrom(report);
                await JsonSerializer.SerializeAsync(httpContext.Response.Body, value, HealthChecksResultsSourceGenerator.Default.TrimmedHealthReport).ConfigureAwait(continueOnCapturedContext: false);
            }
            else
            {
                await httpContext.Response.BodyWriter.WriteAsync(_emptyResponse).ConfigureAwait(continueOnCapturedContext: false);
            }
        }

    }
}
