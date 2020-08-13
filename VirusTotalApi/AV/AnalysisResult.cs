using System.Text.Json.Serialization;

namespace VirusTotalLib.AV
{
    /// <summary>
    /// Base class representing singular analysis
    /// </summary>
    internal class AnalysisResult : IUrlAnalysisResult, IDomainAnalysisResult, IFileAnalysisResult
    {
        /// <summary>
        /// Normalised result
        /// </summary>
        [JsonPropertyName("category")]
        public IFileAnalysisResult.Categories Category { get; set; }

        /// <summary>
        /// Name of the AV engine
        /// </summary>
        [JsonPropertyName("engine_name")]
        public string EngineName { get; set; }

        /// <summary>
        /// Update of the AV engine
        /// </summary>
        [JsonPropertyName("engine_update")]
        public string EngineUpdate { get; set; }

        /// <summary>
        /// Version of the AV engine
        /// </summary>
        [JsonPropertyName("engine_version")]
        public string EngineVersion { get; set; }

        /// <summary>
        /// Detection method used by AV engine
        /// </summary>
        [JsonPropertyName("method")]
        public string DetectionMethod { get; set; }

        /// <summary>
        /// AV engine result.
        /// </summary>
        [JsonPropertyName("result")]
        public string Result { get; set; }

        IUrlAnalysisResult.Categories IUrlAnalysisResult.Category => (IUrlAnalysisResult.Categories)Category;
        IDomainAnalysisResult.Categories IDomainAnalysisResult.Category => (IDomainAnalysisResult.Categories)Category;
    }

}