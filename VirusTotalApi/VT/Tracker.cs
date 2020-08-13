using System.Text.Json.Serialization;

namespace VirusTotalLib.VT
{
    /// <summary>
    /// Represents a site tracker
    /// </summary>
    internal struct Tracker
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
