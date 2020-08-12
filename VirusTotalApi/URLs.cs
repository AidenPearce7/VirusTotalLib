using System;
using System.Collections.Generic;

namespace VirusTotalApi
{
    internal class URLs
    {
        /// <summary>
        /// Key is the partner that categorised the URL, value is the category.
        /// </summary>
        public Dictionary<string, string> Categories { get; set; }


        /// <summary>
        /// Date where the URL was first submitted to VirusTotal
        /// </summary>
        public DateTimeOffset FirstSubmissionDate { get; set; }


    }




    internal class PremiumURLs : URLs
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
        /// <summary>
        /// Includes difference hash and ms5 hash of the URLs favicon
        /// </summary>
        public Dictionary<FaviconEnum,string> Favicon { get; set; }

        


    }
}
