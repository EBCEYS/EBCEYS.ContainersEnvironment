namespace EBCEYS.ContainersEnvironment.ServiceEnvironment.Converter
{
    /// <summary>
    /// A <see cref="DefaultEnvConverter"/> class.
    /// </summary>
    public class DefaultEnvConverter : IEnvironmentConverter
    {
        /// <summary>
        /// Instance of <see cref="DefaultEnvConverter"/>.
        /// </summary>
        public static IEnvironmentConverter Instance { get; } = new DefaultEnvConverter();
        /// <summary>
        /// Converts <paramref name="environmentVariable"/> to <typeparamref name="T"/> object.
        /// </summary>
        /// <param name="environmentVariable">The environment variable string.</param>
        /// <param name="throwConverterException">Throw converter exception.</param>
        /// <typeparam name="T">Type convert to.</typeparam>
        /// <returns><see cref="object"/> converted to <typeparamref name="T"/> or <c>null</c> if catched any exceptions while converting or <paramref name="environmentVariable"/> is <see cref="string.IsNullOrWhiteSpace(string?)"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public T? ConvertTo<T>(string? environmentVariable, bool throwConverterException = false)
        {
            if (string.IsNullOrWhiteSpace(environmentVariable))
            {
                return default;
            }
            object? value = ConvertTo(environmentVariable, typeof(T));
            return value != null ? (T)value : default;
        }
        /// <summary>
        /// Tries to convert <paramref name="environmentVariable"/> to <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type convert to.</typeparam>
        /// <param name="environmentVariable">The environment variable string.</param>
        /// <param name="value">Instance of <typeparamref name="T"/> if converted successfully; otherwise <c>default</c>.</param>
        /// <returns><c>true</c> if <paramref name="environmentVariable"/> converted sucessfully; otherwise <c>false</c>.</returns>
        public bool TryConvertTo<T>(string? environmentVariable, out T? value)
        {
            value = ConvertTo<T>(environmentVariable);
            return value != null;
        }

        private static object? ConvertTo(string? environmentVariable, Type type, bool throwConverterException = false)
        {
            if (string.IsNullOrWhiteSpace(environmentVariable))
            {
                return null;
            }

            ArgumentNullException.ThrowIfNull(type, nameof(type));

            try
            {
                return Convert.ChangeType(environmentVariable, type);
            }
            catch (Exception)
            {
                if (throwConverterException)
                {
                    throw;
                }
            }
            return null;
        }

    }
}
