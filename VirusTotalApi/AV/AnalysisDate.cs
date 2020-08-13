using System;
using System.Text.Json.Serialization;

namespace VirusTotalApi.AV
{
    internal class AnalysisDate
    {
        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }
    }
    public interface IAnalysisDate
    {
        DateTimeOffset Date { get; }
    }
}