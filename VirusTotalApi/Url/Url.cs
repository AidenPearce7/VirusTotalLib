using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using VirusTotalLib.AV;
using VirusTotalLib.VT;

namespace VirusTotalLib.Url
{
    internal class Url : IUrl
    {
        /// <summary>
        /// Key is the partner that categorised the URL, value is the category.
        /// </summary>
        [JsonPropertyName("categories")]
        public Dictionary<string, string> Categories { get; set; }


        /// <summary>
        /// Date where the URL was first submitted to VirusTotal
        /// </summary>
        [JsonPropertyName("first_submission_date")]
        [JsonConverter(typeof(Converters.DateTimeOffsetConverter))]
        public DateTimeOffset FirstSubmissionDate { get; set; }

        /// <summary>
        /// Contains all meta tags
        /// </summary>
        [JsonPropertyName("html_meta")]
        public Dictionary<string, string[]> HtmlMeta { get; set; }

        /// <summary>
        /// Represents last time the Url was scanned
        /// </summary>
        [JsonPropertyName("last_analysis_date")]
        [JsonConverter(typeof(Converters.DateTimeOffsetConverter))]
        public DateTimeOffset LastAnalysisDate { get; set; }

        /// <summary>
        /// Result from URl scanners, scanner name is key
        /// </summary>
        [JsonPropertyName("last_analysis_results")]
        [JsonConverter(typeof(Converters.DictAnalysisResult))]
        public Dictionary<string, AV.IUrlAnalysisResult> LastAnalysisResults { get; set; }
        /// <summary>
        /// Number of different results from this scans
        /// </summary>
        [JsonPropertyName("last_analysis_stats")]
        [JsonConverter(typeof(Converters.StatisticsConverter))]
        public AV.IUrlAnalysisStatistics Statistics { get; set; }
        /// <summary>
        /// if the origianl Url redirets, where does it end
        /// </summary>
        [JsonPropertyName("last_final_url")]
        public string LastFinalUrl { get; set; }
        /// <summary>
        /// HTTP response code of the content received
        /// </summary>
        [JsonPropertyName("last_http_response_code")]
        public int LastHttpResponseCode { get; set; }
        /// <summary>
        /// Length in bytes of the content recieved
        /// </summary>
        [JsonPropertyName("last_http_response_content_length")]
        public int LastHttpResponseContentLength { get; set; }
        /// <summary>
        /// Url response body's SHA256 hash
        /// </summary>
        [JsonPropertyName("last_http_response_content_sha256")]
        public string LastHttpResponseContentSha256 { get; set; }
        /// <summary>
        /// Contains the website's cookies
        /// </summary>
        [JsonPropertyName("last_http_response_cookies")]
        public Dictionary<string, string> LastHttpResponseCookies { get; set; }
        /// <summary>
        /// Contains headers and values of last HTTP response
        /// </summary>
        [JsonPropertyName("last_http_response_headers")]
        public Dictionary<string, string> LastHttpResponseHeaders { get; set; }
        /// <summary>
        /// Represents last modification date
        /// </summary>
        [JsonPropertyName("last_modification_date")]
        [JsonConverter(typeof(Converters.DateTimeOffsetConverter))]
        public DateTimeOffset LastModificationDate { get; set; }
        /// <summary>
        /// Represents the last time it was sent to be analysed
        /// </summary>
        [JsonPropertyName("last_submission_date")]
        [JsonConverter(typeof(Converters.DateTimeOffsetConverter))]
        public DateTimeOffset LastSubmissionDate { get; set; }
        /// <summary>
        /// Contains links to different domains
        /// </summary>
        [JsonPropertyName("outgoing_links")]
        public List<string> OutgoingLinks { get; set; }
        /// <summary>
        /// Value of votes from VirusTotal community
        /// </summary>
        [JsonPropertyName("reputation")]
        public int Reputation { get; set; }
        /// <summary>
        /// Tags
        /// </summary>
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
        /// <summary>
        /// Targeted brand info extracted from phishing engines
        /// </summary>
        [JsonPropertyName("targeted_brand")]
        public Dictionary<string, string> TargetedBrand { get; set; }
        /// <summary>
        /// Number of times that Url has been checked
        /// </summary>
        [JsonPropertyName("times_submitted")]
        public int TimesSubmitted { get; set; }

        /// <summary>
        /// Webpage title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Contains votes from VirusTotal community
        /// </summary>
        [JsonPropertyName("total_votes")]
        [JsonConverter(typeof(Converters.VotesConverter))]
        public VT.IVotes TotalVotes { get; set; }

        /// <summary>
        /// Contains tracker information
        /// </summary>
        [JsonPropertyName("trackers")]
        [JsonConverter(typeof(Converters.DictTrackers))]
        public Dictionary<string, VT.ITracker[]> Trackers { get; set; }

        /// <summary>
        /// Original URL to be scanned
        /// </summary>
        [JsonPropertyName("url")]
        public string OrignialUrl { get; set; }

        IReadOnlyDictionary<string, string> IUrl.Categories => Categories;

        IReadOnlyDictionary<string, string[]> IUrl.HtmlMeta => HtmlMeta;

        IReadOnlyDictionary<string, IUrlAnalysisResult> IUrl.LastAnalysisResults => LastAnalysisResults;

        IReadOnlyDictionary<string, string> IUrl.LastHttpResponseCookies => LastHttpResponseCookies;

        IReadOnlyDictionary<string, string> IUrl.LastHttpResponseHeaders => LastHttpResponseHeaders;

        IReadOnlyDictionary<string, string> IUrl.TargetedBrand => TargetedBrand;

        IReadOnlyDictionary<string, ITracker[]> IUrl.Trackers => Trackers;

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Url)) return false;
            if (((Url)obj).OrignialUrl == OrignialUrl) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        async Task IUrl.Serialize(Stream stream, JsonSerializerOptions options, CancellationToken cancellationToken)
        {
            await JsonSerializer.SerializeAsync<Url>(stream, this, options, cancellationToken);
        }

        public override string ToString()
        {
            return OrignialUrl;
        }
    }
    /// <summary>
    /// Extenction of the Url displaying premium features
    /// </summary>
    internal class PremiumUrl : Url, IPremiumUrl
    {
        /// <summary>
        /// Includes difference hash and ms5 hash of the URLs favicon
        /// </summary>
        public Dictionary<IPremiumUrl.FaviconEnum, string> Favicon { get; set; }

        IReadOnlyDictionary<IPremiumUrl.FaviconEnum, string> IPremiumUrl.Favicon => Favicon;
        async Task IPremiumUrl.Serialize(Stream stream, JsonSerializerOptions options, CancellationToken cancellationToken)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            await JsonSerializer.SerializeAsync<PremiumUrl>(stream, this, options, cancellationToken);
        }
    }
}