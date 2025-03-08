using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace EBCEYS.ContainersEnvironment.HealthChecks
{
    /// <summary>
    /// A <see cref="PingServiceHealthStatusInfo"/> class.
    /// </summary>
    public class PingServiceHealthStatusInfo(ILogger<PingServiceHealthStatusInfo> logger)
    {
        /// <summary>
        /// The route for this health check.
        /// </summary>
        public const string HealthCheckName = "PingServiceCheck";
        /// <summary>
        /// The health status.
        /// </summary>
        public HealthStatus Status { get; private set; } = HealthStatus.Healthy;
        /// <summary>
        /// The message.
        /// </summary>
        public string Message { get; private set; } = "OK";
        /// <summary>
        /// Gets the <see cref="HealthCheckResult"/> by <see cref="Status"/> and <see cref="Message"/>.
        /// </summary>
        /// <returns>A new instance of <see cref="HealthCheckResult"/>.</returns>
        public HealthCheckResult GetResult()
        {
            return new(Status, Message);
        }
        /// <summary>
        /// Sets the <see cref="HealthStatus.Healthy"/>.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SetHealthyStatus(string message = "OK")
        {
            Status = HealthStatus.Healthy;
            Message = message;
            logger.LogTrace("Set health status {status}", Status);
        }
        /// <summary>
        /// Sets the unhealthy status.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SetUnhealthyStatus(string message = "UNHEALTHY")
        {
            Status = HealthStatus.Unhealthy;
            Message = message;
            logger.LogTrace("Set health status {status}", Status);
        }
        /// <summary>
        /// Sets the unhealthy status with <see cref="Message"/> set as <paramref name="ex"/>.<see cref="Exception.ToString()"/>;
        /// </summary>
        /// <param name="ex">The exception.</param>
        public void SetUnhealthyStatus(Exception ex)
        {
            Status = HealthStatus.Unhealthy;
            Message = ex.ToString();
            logger.LogTrace("Set health status {status}", Status);
        }
    }
    /// <summary>
    /// A <see cref="PingHealthCheck"/> class.
    /// </summary>
    public class PingHealthCheck(PingServiceHealthStatusInfo ping) : IHealthCheck
    {
        /// <inheritdoc/>
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(ping.GetResult());
        }
    }
}
