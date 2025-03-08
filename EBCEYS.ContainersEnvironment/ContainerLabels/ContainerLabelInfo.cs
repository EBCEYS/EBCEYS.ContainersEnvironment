namespace EBCEYS.ContainersEnvironment.ContainerLabels
{
    /// <summary>
    /// A <see cref="ContainerLabelInfo{T}"/> class.
    /// </summary>
    /// <typeparam name="T">The <see cref="Value"/> type.</typeparam>
    /// <remarks>
    /// Initiates a new instance of <see cref="ContainerLabelInfo{T}"/>.
    /// </remarks>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public class ContainerLabelInfo<T>(string key, T? value)
    {
        /// <summary>
        /// The key.
        /// </summary>
        public string Key { get; } = key;
        /// <summary>
        /// The value.
        /// </summary>
        public T? Value { get; } = value;
    }
}
