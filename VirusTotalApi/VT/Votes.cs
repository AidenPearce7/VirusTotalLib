using System.Text.Json.Serialization;

namespace VirusTotalLib.VT
{
    /// <summary>
    /// Represents Votes in VirusTotal community
    /// </summary>
    internal struct Votes : IVotes
    {
        /// <summary>
        /// Positive votes
        /// </summary>
        [JsonPropertyName("harmless")]
        public int Harmless { get; set; }
        /// <summary>
        /// Negative votes
        /// </summary>
        [JsonPropertyName("malicious")]
        public int Malicious { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Votes)) return false;
            Votes votes = (Votes)obj;
            if (votes.Harmless != Harmless
                || votes.Malicious != Malicious) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    /// <inheritdoc cref="Votes"/>
    public interface IVotes
    {
        /// <inheritdoc cref="Votes.Harmless"/>
        int Harmless { get; }
        /// <inheritdoc cref="Votes.Malicious"/>
        int Malicious { get; }
    }
}
