using System.Text.Json.Serialization;

namespace EBCEYS.ContainersEnvironment.Configuration.Models
{
    /// <summary>
    /// A <see cref="ConfigurationFileInfo"/> class.
    /// </summary>
    /// <remarks>
    /// Initiates a new instance of <see cref="ConfigurationFileInfo"/>.
    /// </remarks>
    /// <param name="serverFileFullPath">The server file full path.</param>
    /// <param name="lastWriteUTC">The last write UTC.</param>
    /// <param name="containerTypeName">The container type name.</param>
    /// <param name="fileSaveFullPath">The file save full path.</param>
    [JsonDerivedType(typeof(ConfigurationFileInfo))]
    public class ConfigurationFileInfo(string serverFileFullPath, DateTimeOffset lastWriteUTC, string containerTypeName, string fileSaveFullPath)
    {
        /// <summary>
        /// The server file full path.
        /// </summary>
        public string ServerFileFullPath { get; set; } = serverFileFullPath;
        /// <summary>
        /// The file last write UTC.
        /// </summary>
        public DateTimeOffset LastWriteUTC { get; set; } = lastWriteUTC;
        /// <summary>
        /// The container type name.
        /// </summary>
        public string ContainerTypeName { get; set; } = containerTypeName;
        /// <summary>
        /// The file save full path.
        /// </summary>
        public string FileSaveFullPath { get; set; } = fileSaveFullPath;
    }
}
