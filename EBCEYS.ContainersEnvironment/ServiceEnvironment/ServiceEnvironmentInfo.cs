namespace EBCEYS.ContainersEnvironment.ServiceEnvironment
{
    /// <summary>
    /// Initiates a new instance of <see cref="ServiceEnvironmentInfo"/>.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <param name="description">The description.</param>
    public class ServiceEnvironmentInfo(string key, string? defaultValue, string description)
    {
        private const string DefaultValueNull = "NULL";
        /// <summary>
        /// The key.
        /// </summary>
        public string Key { get; } = key;
        /// <summary>
        /// The default value description.
        /// </summary>
        public string DefaultValue { get; } = defaultValue ?? DefaultValueNull;
        /// <summary>
        /// The description.
        /// </summary>
        public string Description { get; } = description;
        /// <summary>
        /// Gets the <see cref="string"/> representation of <see cref="ServiceEnvironmentInfo"/>.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"\t{Key} (default value is {DefaultValue}) ---> {Description}";
        }
    }
}
