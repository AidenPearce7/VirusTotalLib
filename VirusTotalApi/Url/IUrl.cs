using System;
using System.Collections.Generic;

namespace VirusTotalLib.Url
{
    /// <inheritdoc cref="Url"/>
    public interface IUrl
    {
        /// <inheritdoc cref="Url.Categories"/>
        public IReadOnlyDictionary<string, string> Categories { get; }
        /// <inheritdoc cref="Url.FirstSubmissionDate"/>
        public DateTimeOffset FirstSubmissionDate { get; }
        /// <inheritdoc cref="Url.HtmlMeta"/>
        public IReadOnlyDictionary<string, string[]> HtmlMeta { get; }
        /// <inheritdoc cref="Url.LastAnalysisDate"/>
        public DateTimeOffset LastAnalysisDate { get; }
        /// <inheritdoc cref="Url.LastAnalysisResults"/>
        public IReadOnlyDictionary<string, AV.IUrlAnalysisResult> LastAnalysisResults { get; }
        /// <inheritdoc cref="Url.Statistics"/>
        public AV.IUrlAnalysisStatistics Statistics { get; }
        /// <inheritdoc cref="Url.LastFinalUrl"/>
        public string LastFinalUrl { get; }
        /// <inheritdoc cref="Url.LastHttpResponseCode"/>
        public int LastHttpResponseCode { get; }
        /// <inheritdoc cref="Url.LastHttpResponseContentLength"/>
        public int LastHttpResponseContentLength { get; }
        /// <inheritdoc cref="Url.LastHttpResponseContentSha256"/>
        public string LastHttpResponseContentSha256 { get; }
        /// <inheritdoc cref="Url.LastHttpResponseCookies"/>
        public IReadOnlyDictionary<string, string> LastHttpResponseCookies { get; }
        /// <inheritdoc cref="Url.LastHttpResponseHeaders"/>
        public IReadOnlyDictionary<string, string> LastHttpResponseHeaders { get; }
        /// <inheritdoc cref="Url.LastModificationDate"/>
        public DateTimeOffset LastModificationDate { get; }
        /// <inheritdoc cref="Url.LastSubmissionDate"/>
        public DateTimeOffset LastSubmissionDate { get; }
        /// <inheritdoc cref="Url.links"/>
        public List<string> OutgoingLinks { get; }
        /// <inheritdoc cref="Url.Reputation"/>
        public int Reputation { get; }
        /// <inheritdoc cref="Url.Tags"/>
        public List<string> Tags { get; }
        /// <inheritdoc cref="Url.TargetedBrand"/>
        public IReadOnlyDictionary<string, string> TargetedBrand { get; }
        /// <inheritdoc cref="Url.TimesSubmitted"/>
        public int TimesSubmitted { get; }
        /// <inheritdoc cref="Url.Title"/>
        public string Title { get; }
        /// <inheritdoc cref="Url.TotalVotes"/>
        public VT.IVotes TotalVotes { get; }
        /// <inheritdoc cref="Url.Trackers"/>
        public IReadOnlyDictionary<string, VT.ITracker[]> Trackers { get; }
        /// <inheritdoc cref="Url.OrignialUrl"/>
        public string OrignialUrl { get; }

    }
    /// <inheritdoc cref="PremiumUrl"/>
    public interface IPremiumUrl : IUrl
    {
        [Flags]
        public enum FaviconEnum
        {
            /// <summary>
            /// Difference hash
            /// </summary>
            dhash,
            /// <summary>
            /// favicons MD5 hash
            /// </summary>
            raw_md5
        }
        /// <inheritdoc cref="PremiumUrl.Favicon"/>
        IReadOnlyDictionary<FaviconEnum, string> Favicon { get; }
    }
}
