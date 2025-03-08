using EBCEYS.ContainersEnvironment.ServiceEnvironment;

namespace EBCEYS.ContainersEnvironment.HealthChecks.Environment
{
    /// <summary>
    /// A <see cref="HealthChecksEnvironmentVariables"/>.
    /// </summary>
    public static class HealthChecksEnvironmentVariables
    {
        private const string healthChecksPort = "HEALTHCHECKS_STARTING_PORT";
        internal const int StartingPort = 8080;
        /// <summary>
        /// The healthchecks starting port.
        /// </summary>
        public static ServiceEnvironmentVariable<int> HealthChecksPort { get; } = new(healthChecksPort, StartingPort);
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
