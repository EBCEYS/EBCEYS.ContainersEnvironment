namespace EBCEYS.ContainersEnvironment.ServiceEnvironment
{
    /// <summary>
    /// Default environment variables.
    /// </summary>
    public static class DefaultEnvironmentVariables
    {
        private const string containerNameKey = "CONTAINER_NAME";
        private const string containerNameDesc = "Returns container name if exists; otherwise Environment.MachineName";
        /// <summary>
        /// Returns the container name if exists; otherwise <see cref="Environment.MachineName"/>.
        /// </summary>
        public static ServiceEnvironmentVariable<string> ContainerName { get; } = new(containerNameKey, Environment.MachineName, containerNameDesc);
        /// <summary>
        /// Gets the default environment variables info collection.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ServiceEnvironmentInfo> GetVariablesInfo()
        {
            return [ContainerName.GetInfo()];
        }
    }
}
