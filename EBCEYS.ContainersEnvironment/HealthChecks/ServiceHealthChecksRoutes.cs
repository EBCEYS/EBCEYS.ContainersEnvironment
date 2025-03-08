namespace EBCEYS.ContainersEnvironment.HealthChecks
{
    /// <summary>
    /// A <see cref="ServiceHealthChecksRoutes"/>.
    /// </summary>
    public static class ServiceHealthChecksRoutes
    {
        /// <summary>
        /// The ping route.
        /// </summary>
        public const string PingRoute = "/ping";
        /// <summary>
        /// The healthz route.
        /// </summary>
        public const string HealthzRoute = "/healthz";
        /// <summary>
        /// The healthz status route.
        /// </summary>
        public const string HealthzStatusRoute = "/healthz/status";
    }
}
