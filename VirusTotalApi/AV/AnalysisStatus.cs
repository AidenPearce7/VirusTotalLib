using System;
using System.Text.Json.Serialization;

namespace VirusTotalLib.AV
{
    internal class AnalysisStatus : IAnalysisStatus
    {
        [JsonPropertyName("status")]
        public IAnalysisStatus.Statuses Status { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is AnalysisStatus)) return false;
            if (((AnalysisStatus)obj).Status == Status) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Status.ToString();
        }
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