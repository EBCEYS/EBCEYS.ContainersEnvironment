using System.ComponentModel;
using System.Text.Json.Serialization;
using HealthChecks.UI.Core;

namespace EBCEYS.ContainersEnvironment.HealthChecks.Models
{
    [JsonSourceGenerationOptions(AllowTrailingCommas = true, Converters = [typeof(JsonStringEnumConverter<UIHealthStatus>), typeof(TimeSpanConverter)], 
        PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        UseStringEnumConverter = true)]
    [JsonSerializable(typeof(TrimmedHealthReport))]
    [JsonSerializable(typeof(TrimmedHealthReportEntry))]
    [JsonSerializable(typeof(Dictionary<string, TrimmedHealthReportEntry>))]
    internal partial class HealthChecksResultsSourceGenerator : JsonSerializerContext { }
}
