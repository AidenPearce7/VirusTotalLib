using System;

namespace VirusTotalApi.AV
{
    /// <summary>
    /// Represents the analysis object returned during domain analysis
    /// </summary>
    public interface IDomainAnalysisResult
    {
        /// <summary>
        /// Normalized result of an analysis
        /// </summary>
        [Flags]
        enum Categories
        {
            /// <summary>
            /// Site is not malicious
            /// </summary>
            Harmless = 4,
            /// <summary>
            /// Scanner thinks the site is malicious
            /// </summary>
            Malicious = 8,
            /// <summary>
            /// Scanner thinks the site is suspicious
            /// </summary>
            Suspicious = 16,
            /// <summary>
            /// Scanner has no opinion about this site
            /// </summary>
            Undetected = 64
        }

        /// <inheritdoc cref="AnalysisResult.Category"/>
        Categories Category { get; }

        /// <inheritdoc cref="AnalysisResult.EngineName"/>
        string EngineName { get; }
        /// <inheritdoc cref="AnalysisResult.EngineVersion"/>
        string EngineVersion { get; }
        /// <inheritdoc cref="AnalysisResult.DetectionMethod"/>
        string DetectionMethod { get; }
        /// <inheritdoc cref="AnalysisResult.Result"/>
        string Result { get; }
    }

    public interface IDomainAnalysisStatistics
    {
        public int Harmless { get; }
        public int Malicious { get; }
        public int Suspicious { get; }
        public int Timeout { get; }
        public int Undetected { get; }

    }
}