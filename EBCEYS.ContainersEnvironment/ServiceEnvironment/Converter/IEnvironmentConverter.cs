namespace EBCEYS.ContainersEnvironment.ServiceEnvironment.Converter
{
    /// <summary>
    /// A <see cref="IEnvironmentConverter"/> interface.
    /// </summary>
    public interface IEnvironmentConverter
    {
        /// <summary>
        /// Converts <paramref name="environmentVariable"/> to <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type convert to.</typeparam>
        /// <param name="environmentVariable">The environment variable.</param>
        /// <param name="throwConverterException">Throw converter exception.</param>
        /// <returns>Instance of <paramref name="environmentVariable"/> conveted to <typeparamref name="T"/> or <c>default</c>.</returns>
        T? ConvertTo<T>(string? environmentVariable, bool throwConverterException = false);
        /// <summary>
        /// Tries to convert <paramref name="environmentVariable"/> to <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type convert to.</typeparam>
        /// <param name="environmentVariable">The environment variable.</param>
        /// <param name="value">The result value if converted successfully; otherwise <c>default</c>.</param>
        /// <returns><c>true</c> if converted successfully; otherwise <c>false</c>.</returns>
        bool TryConvertTo<T>(string? environmentVariable, out T? value);
    }
}