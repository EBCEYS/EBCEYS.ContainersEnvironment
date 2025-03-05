using EBCEYS.ContainersEnvironment.ServiceEnvironment;

namespace EBCEYS.ContainersEnvironment.Configuration.Environment
{
    /// <summary>
    /// A <see cref="ConfigurationEnvironment"/> class.
    /// </summary>
    public static class ConfigurationEnvironment
    {
        private const string configurationContainerTypeName = "CONFIGURATION_CONTAINER_TYPE_NAME";
        private const string configurationServerUrl = "CONFIGURATION_SERVER_URI";
        private const string configurationSaveDirectory = "CONFIGURATION_SAVE_DIRECTORY";
        /// <summary>
        /// The container type name.
        /// </summary>
        public static ServiceEnvironmentVariable<string> ConfigurationContainerTypeName { get; } = new(configurationContainerTypeName, DefaultEnvironmentVariables.ContainerName.Value);
        /// <summary>
        /// The server url.
        /// </summary>
        public static ServiceEnvironmentVariable<string> ConfigurationServerUrl { get; } = new(configurationServerUrl, "http://server-configuration:3000");
        /// <summary>
        /// The configuration save directory.
        /// </summary>
        public static ServiceEnvironmentVariable<string> ConfigurationSaveDirectory { get; } = new(configurationSaveDirectory, "/");
        /// <summary>
        /// Gets the <see cref="ServiceEnvironmentInfo"/> of all supported variables.
        /// </summary>
        /// <returns>Collection of <see cref="ServiceEnvironmentInfo"/>.</returns>
        public static IEnumerable<ServiceEnvironmentInfo> GetInfo()
        {
            return
                [
                ConfigurationContainerTypeName.GetInfo(),
                ConfigurationServerUrl.GetInfo(),
                ConfigurationSaveDirectory.GetInfo(),
                ];
        }
    }
}
