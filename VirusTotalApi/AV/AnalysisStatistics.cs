using System.Text.Json.Serialization;

namespace VirusTotalLib.AV
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

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is AnalysisStatistics)) return false;
            AnalysisStatistics stats = obj as AnalysisStatistics;
            if (stats.ConfirmedTimeout != ConfirmedTimeout
                || stats.Harmless != Harmless
                || stats.Failure != Failure
                || stats.Malicious != Malicious
                || stats.Suspicious != Suspicious
                || stats.Timeout != Timeout
                || stats.TypeUnsupported != TypeUnsupported
                || stats.Undetected != Undetected) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString(); //We don't have to do anything here. There's nothing that would benifit from using this method here.
        }
    }

}