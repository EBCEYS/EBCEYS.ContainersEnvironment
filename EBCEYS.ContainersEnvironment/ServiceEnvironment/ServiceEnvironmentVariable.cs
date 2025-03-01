using System.Diagnostics.CodeAnalysis;
using EBCEYS.ContainersEnvironment.ServiceEnvironment.Converter;

namespace EBCEYS.ContainersEnvironment.ServiceEnvironment
{
    /// <summary>
    /// A <see cref="ServiceEnvironmentVariable{T}"/> class.
    /// </summary>
    /// <typeparam name="T"><see cref="Value"/> type.</typeparam>
    public class ServiceEnvironmentVariable<T>
    {
        private const string defaultKeyValue = "DefaultKey";
        /// <summary>
        /// The key.
        /// </summary>
        public string Key { get; }
        /// <summary>
        /// The description.
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// The value.
        /// </summary>
        public T? Value { get; }
        /// <summary>
        /// The default value.
        /// </summary>
        public T? DefaultValue { get; }
        /// <summary>
        /// Initiates a new instance of <see cref="ServiceEnvironmentVariable{T}"/>.<br/>
        /// <see cref="Value"/> will return <paramref name="defaultValue"/> if there's no such variable in environment.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="description">The description.</param>
        /// <param name="converter">The environment converter.<br/>Will use <see cref="DefaultEnvConverter"/> if <paramref name="converter"/> is <c>null</c>.</param>
        public ServiceEnvironmentVariable(string? key, T? defaultValue = default, string? description = default, IEnvironmentConverter? converter = null)
        {
            Key = key ?? defaultKeyValue;
            Description = description ?? Key;
            DefaultValue = defaultValue;
            converter ??= new DefaultEnvConverter();
            if (converter.TryConvertTo<T>(Environment.GetEnvironmentVariable(Key), out T? value))
            {
                Value = value;
            }
            else
            {
                Value = defaultValue;
            }
        }
        /// <summary>
        /// Gets <see cref="ServiceEnvironmentInfo"/> for this variable.
        /// </summary>
        /// <returns></returns>
        public ServiceEnvironmentInfo GetInfo()
        {
            return new(Key, DefaultValue?.ToString(), Description);
        }
        /// <inheritdoc/>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is ServiceEnvironmentVariable<T> val)
            {
                return this == val;
            }
            return false;
        }
        /// <summary>
        /// Checks the equality of two <see cref="ServiceEnvironmentVariable{T}"/>.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns><c>true</c> if variables have equal <see cref="Key"/> and <see cref="Value"/>; otherwise <c>false</c>.</returns>
        public static bool operator ==(ServiceEnvironmentVariable<T> left, ServiceEnvironmentVariable<T> right)
        {
            return left.Key == right.Key && (left.Value?.Equals(right.Value) ?? right.Value is null);
        }
        /// <summary>
        /// Checks the unequality of two <see cref="ServiceEnvironmentVariable{T}"/>.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is not equal to <paramref name="right"/>; otherwise <c>false</c>.</returns>
        public static bool operator !=(ServiceEnvironmentVariable<T> left, ServiceEnvironmentVariable<T> right)
        {
            return !(left == right);
        }
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
