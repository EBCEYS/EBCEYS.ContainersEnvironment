namespace EBCEYS.ContainersEnvironment.ContainerLabels
{
    /// <summary>
    /// A <see cref="ContainerLabelInfo{T}"/> class.
    /// </summary>
    /// <typeparam name="T">The <see cref="Value"/> type.</typeparam>
    public class ContainerLabelInfo<T>
    {
        /// <summary>
        /// The key.
        /// </summary>
        public string Key { get; }
        /// <summary>
        /// The value.
        /// </summary>
        public T? Value { get; }
        /// <summary>
        /// Initiates a new instance of <see cref="ContainerLabelInfo{T}"/>.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public ContainerLabelInfo(string key, T? value)
        {
            Key = key;
            Value = value;
        }
    }
}
