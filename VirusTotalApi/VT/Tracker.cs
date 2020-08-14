using System.Text.Json.Serialization;

namespace VirusTotalLib.VT
{
    /// <summary>
    /// Represents a site tracker
    /// </summary>
    internal struct Tracker : ITracker
    {
        /// <summary>
        /// Id of the tracker
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Location of the tracker
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Tracker)) return false;
            Tracker tracker = (Tracker)obj;
            if (tracker.Id != Id
                || tracker.Url != Url) return false;
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
    /// <inheritdoc cref="Tracker"/>
    public interface ITracker
    {
        /// <inheritdoc cref="Tracker.Id"/>
        string Id { get; }
        /// <inheritdoc cref="Tracker.Url"/>
        string Url { get; }
    }
}
