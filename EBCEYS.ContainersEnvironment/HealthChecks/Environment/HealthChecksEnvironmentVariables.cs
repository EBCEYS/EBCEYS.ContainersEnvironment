using EBCEYS.ContainersEnvironment.ServiceEnvironment;

namespace EBCEYS.ContainersEnvironment.HealthChecks.Environment
{
    /// <summary>
    /// A <see cref="HealthChecksEnvironmentVariables"/>.
    /// </summary>
    public static class HealthChecksEnvironmentVariables
    {
        private const string healthChecksPort = "HEALTHCHECKS_STARTING_PORT";
        private const string enableHealthChecks = "HEALTHCHECKS_ENABLE";
        /// <summary>
        /// The healthchecks starting port. Default is <c>8080</c>.
        /// </summary>
        public static ServiceEnvironmentVariable<int?> HealthChecksPort { get; } = new(healthChecksPort, 8080);
        /// <summary>
        /// The healthchecks are enabled. Default is <c>true</c>.
        /// </summary>
        public static ServiceEnvironmentVariable<bool?> HealthChecksEnabled { get; } = new(enableHealthChecks, true);
        /// <summary>
        /// Gets the info of all <see cref="ServiceEnvironmentVariable{T}"/> in <see cref="HealthChecksEnvironmentVariables"/>.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ServiceEnvironmentInfo> GetInfo()
        {
            return [HealthChecksPort.GetInfo()];
        }
    }
}
