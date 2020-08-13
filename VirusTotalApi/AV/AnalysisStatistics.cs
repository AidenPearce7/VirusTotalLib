using System.Text.Json.Serialization;

namespace VirusTotalApi.AV
{
    internal class AnalysisStatistics : IUrlAnalysisStatistics, IDomainAnalysisStatistics, IFileAnalysisStatistics
    {
        [JsonPropertyName("confirmed-timeout")]
        public int ConfirmedTimeout { get; set; }
        [JsonPropertyName("harmless")]
        public int Harmless { get; set; }
        [JsonPropertyName("failure")]
        public int Failure { get; set; }
        [JsonPropertyName("malicious")]
        public int Malicious { get; set; }
        [JsonPropertyName("suspicious")]
        public int Suspicious { get; set; }
        [JsonPropertyName("timeout")]
        public int Timeout { get; set; }
        [JsonPropertyName("type-unsupported")]
        public int TypeUnsupported { get; set; }
        [JsonPropertyName("undetected")]
        public int Undetected { get; set; }
    }

}