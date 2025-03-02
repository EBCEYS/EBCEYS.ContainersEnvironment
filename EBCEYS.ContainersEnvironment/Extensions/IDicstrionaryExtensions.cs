using EBCEYS.ContainersEnvironment.ContainerLabels;
using EBCEYS.ContainersEnvironment.ServiceEnvironment.Converter;

namespace EBCEYS.ContainersEnvironment.Extensions
{
    /// <summary>
    /// A <see cref="IDicstrionaryExtensions"/> class.
    /// </summary>
    public static class IDicstrionaryExtensions
    {
        /// <summary>
        /// Gets the <see cref="ContainerLabelInfo{T}"/> from labels dictionary.
        /// </summary>
        /// <typeparam name="T">The <see cref="ContainerLabelInfo{T}.Value"/> type.</typeparam>
        /// <param name="labels">The labels dict.</param>
        /// <param name="key">The label key.</param>
        /// <param name="converter">The converter. If <c>null</c> will be used <see cref="DefaultEnvConverter"/>.</param>
        /// <returns>An instance of <see cref="ContainerLabelInfo{T}"/> if <paramref name="labels"/> contains <paramref name="key"/>; otherwise <c>null</c>.<br/>
        /// <see cref="ContainerLabelInfo{T}.Value"/> will be default on unsuccessfull convertion.</returns>
        public static ContainerLabelInfo<T>? GetLabel<T>(this IDictionary<string, string> labels, string key, IEnvironmentConverter? converter = null)
        {
            if (labels.TryGetValue(key, out string? value) && value != default)
            {
                converter ??= new DefaultEnvConverter();
                if (converter.TryConvertTo(value, out T? convetedValue) && convetedValue != null)
                {
                    return new ContainerLabelInfo<T>(key, convetedValue);
                }
                return new(key, default);

            }
            return null;
        }
    }
}
