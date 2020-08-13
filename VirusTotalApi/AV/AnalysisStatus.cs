using System;
using System.Text.Json.Serialization;

namespace VirusTotalLib.AV
{
    internal class AnalysisStatus : IAnalysisStatus
    {
        [JsonPropertyName("status")]
        public IAnalysisStatus.Statuses Status { get; set; }
    }
    public interface IAnalysisStatus
    {
        [Flags]
        enum Statuses
        {
            Completed = 1,
            Queued = 2,
            InProgress = 4
        }
        Statuses Status { get; }
    }


}