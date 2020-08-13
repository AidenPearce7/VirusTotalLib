using System;

namespace VirusTotalApi.AV
{
    /// <summary>
    /// Represents the analysis object returned during File analysis
    /// </summary>
    public interface IFileAnalysis
    {
        [Flags]
        /// <inheritdoc cref="IDomainAnalysis.Categories"/>
        enum Categories
        {
            ConfirmedTimeout = 1,
            Failure = 2,
            Harmless = 4,
            Malicious = 8,
            Suspicious = 16,
            TypeUnsupported = 32,
            Undetected = 64
        }

        /// <inheritdoc cref="AnalysisResult.Category"/>
        public Categories Category { get; }

        /// <inheritdoc cref="AnalysisResult.EngineName"/>
        public string EngineName { get; }

        /// <inheritdoc cref="AnalysisResult.EngineUpdate"/>
        public string EngineUpdate { get; }

        /// <inheritdoc cref="AnalysisResult.EngineVersion"/>
        public string EngineVersion { get; }

        /// <inheritdoc cref="AnalysisResult.DetectionMethod"/>
        public string DetectionMethod { get; }

        /// <inheritdoc cref="AnalysisResult.Result"/>
        public string Result { get; }
    }

}