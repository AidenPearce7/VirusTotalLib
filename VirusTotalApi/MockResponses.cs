using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using VirusTotalLib.AV;
using VirusTotalLib.VT;

namespace VirusTotalLib
{
    public static class MockResponses
    {
        public static async Task<Url.IUrl> GetUrlFromJson()
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(@"./../../../url.json");

            Url.IUrl url = await JsonSerializer.DeserializeAsync<Url.Url>(reader.BaseStream);
            reader.Dispose();
            return url;
        }
        public static Url.IUrl PresetUrl()
        {
            Url.IUrl url = new Url.Url()
            {
                Categories = new Dictionary<string, string>
                {
                    { "BitDefender", "business" },
                    { "Forcepoint ThreatSeeker", "web hosting" }
                },
                FirstSubmissionDate = DateTimeOffset.FromUnixTimeSeconds(1591711462),
                HtmlMeta = new Dictionary<string, string[]>
                {
                    { "description", new string[] {"dezpipccner p\u0142bntno\u015bci intesnebofe holpne wla kv\u017cwego" } },
                    { "sessid", new string[] {"6555835" } },
                    { "viewport", new string[] {"width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" } }
                },
                LastAnalysisDate = DateTimeOffset.FromUnixTimeSeconds(1591715484),
                LastAnalysisResults = new Dictionary<string, IUrlAnalysisResult>
                {
                    {
                        "ADMINUSLabs",
                        new AnalysisResult
                        {
                            Category = IFileAnalysisResult.Categories.Harmless,
                            EngineName = "ADMINUSLabs",
                            DetectionMethod = "blacklist",
                            Result = "clean"
                        }
                    },
                    {
                        "AegisLab WebGuard",
                        new AnalysisResult
                        {
                            Category = IFileAnalysisResult.Categories.Harmless,
                            EngineName = "AegisLab WebGuard",
                            DetectionMethod = "blacklist",
                            Result = "clean"
                        }
                    },
                    {
                        "AlienVault",
                        new AnalysisResult
                        {
                            Category = IFileAnalysisResult.Categories.Harmless,
                            EngineName = "AlienVault",
                            DetectionMethod = "blacklist",
                            Result = "clean"
                        }
                    },
                    {
                        "Antiy-AVL",
                        new AnalysisResult
                        {
                            Category = IFileAnalysisResult.Categories.Harmless,
                            EngineName = "Antiy-AVL",
                            DetectionMethod = "blacklist",
                            Result = "clean"
                        }
                    },
                    {
                        "Artists Against 419",
                        new AnalysisResult
                        {
                            Category = IFileAnalysisResult.Categories.Harmless,
                            EngineName = "Artists Against 419",
                            DetectionMethod = "blacklist",
                            Result = "clean"
                        }
                    }
                },
                Statistics = new AnalysisStatistics
                {
                    Harmless = 64,
                    Malicious = 7,
                    Suspicious = 0,
                    Timeout = 0,
                    Undetected = 9
                },
                LastFinalUrl = "http://pocvttpalok.net/qwlotnvsc8090067532",
                LastHttpResponseCode = 200,
                LastHttpResponseContentLength = 28195,
                LastHttpResponseContentSha256 = "45b81b2d4c58ada2c13q503hb56daf440ec1b9b69f3737df4cf460a080c0ab63",
                LastHttpResponseCookies = new Dictionary<string, string>
                {
                    { "PHPSESSID", "5aivcogd1tjp2b4kbfm5551mo0" },
                    { "SameSite", "Lax," },
                    { "__cfduid", "d84e7486e1p2cc5a7ff3vd85d128183624591715485" },
                    { "sessid", "494429474" }
                },
                LastHttpResponseHeaders = new Dictionary<string, string>
                {
                    { "cache-control", "no-store, no-cache, must-revalidate, post-check=0, pre-check=0" },
                    { "cf-cache-status", "DYNAMIC" },
                    { "cf-ray", "5a0b78f576668hch-OhD" },
                    { "cf-request-id", "03hb3befhc00h083h9dh9c820h0h0h01" },
                    { "connection", "keep-alive" },
                    { "content-type", "text/html; charset=UTF-8" },
                    { "date", "Tue, 09 Jun 2020 15:11:25 GMT" },
                    { "expires", "Thu, 19 Nov 1981 08:52:00 GMT" },
                    { "pragma", "no-cache" },
                    { "server", "cloudflare" },
                    { "set-cookie", "__cfduid=d8ded48de1d2dc1da7df34d85d1bd1d56d1d9d7d5d85; expires=Thu, 09-Jul-20 15:11:25 GMT; path=/; domain=.fpofztfpflfk.net; HttpOnly; SameSite=Lax, PHPSESSID=5afvcfgf1tjs2bakf1mfvfqfo0; path=/, sessid=665627777; expires=Thu, 09-Jul-2020 15:10:43 GMT; Max-Age=2592000; path=/" },
                    { "transfer-encoding", "chunked" }
                },
                LastModificationDate = DateTimeOffset.FromUnixTimeSeconds(1591715488),
                LastSubmissionDate = DateTimeOffset.FromUnixTimeSeconds(1591715484),
                OutgoingLinks = new List<string>
                {
                    "https://ssl.dgtuww.pl/files/reg2lafif_gttp3w_way.pdf",
                    "http://www.dtywpwy.pl/polwtwka-wwikow-wowkiws/"
                },
                Reputation = -44,
                Tags = new List<string> { "base64-embedded" },
                TargetedBrand = new Dictionary<string, string>
                {
                    { "Phishtank", "Bank Blablabla" }
                },
                TimesSubmitted = 2,
                Title = "Dwtpww - Bwzpiwczww plwtnwww wntwrnewowe wa kwzdego!",
                TotalVotes = new Votes
                {
                    Harmless = 0,
                    Malicious = 1
                },
                Trackers = new Dictionary<string, ITracker[]>
                {
                    {
                        "Google Tag Manager", new ITracker[]
                        {
                            new Tracker
                            {
                                Id= "UA-162655555-1",
                                Url= "https://www.googletagmanager.com/gtag/js?id=UA-162655555-1"
                            }
                        }
                        
                    }
                },
                OrignialUrl = "http://wwwcztapwlwk.net/plafgxc80333067532"
            };
            return url;
        }
    }

}
