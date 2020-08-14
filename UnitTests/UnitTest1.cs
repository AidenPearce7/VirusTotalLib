using Xunit;
using VirusTotalLib.Url;
using System.Collections.Generic;
using System.Collections;
using System.Text.Encodings.Web;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public async void UrlJsonParseTest()
        {
            //Given
            IUrl testdata = VirusTotalLib.MockResponses.PresetUrl();
            //When
            IUrl urldata = await VirusTotalLib.MockResponses.GetUrlFromJson();
            //Then

            Assert.True(Compare(testdata.Categories, urldata.Categories),nameof(urldata.Categories));
            Assert.Equal(testdata.FirstSubmissionDate, urldata.FirstSubmissionDate);
            Assert.True(Compare(testdata.HtmlMeta, urldata.HtmlMeta),nameof(urldata.HtmlMeta));
            Assert.Equal(testdata.LastAnalysisDate, urldata.LastAnalysisDate);
            Assert.True(Compare(testdata.LastAnalysisResults, urldata.LastAnalysisResults), nameof (urldata.LastAnalysisResults));
            Assert.Equal(testdata.LastFinalUrl, urldata.LastFinalUrl);
            Assert.Equal(testdata.LastHttpResponseCode, urldata.LastHttpResponseCode);
            Assert.Equal(testdata.LastHttpResponseContentLength, urldata.LastHttpResponseContentLength);
            Assert.Equal(testdata.LastHttpResponseContentSha256, urldata.LastHttpResponseContentSha256);
            Assert.True(Compare(testdata.LastHttpResponseCookies, urldata.LastHttpResponseCookies),nameof(urldata.LastHttpResponseCookies));
            Assert.True(Compare(testdata.LastHttpResponseHeaders, urldata.LastHttpResponseHeaders),nameof(urldata.LastHttpResponseHeaders));
            Assert.Equal(testdata.LastModificationDate, urldata.LastModificationDate);
            Assert.Equal(testdata.LastSubmissionDate, urldata.LastSubmissionDate);
            Assert.Equal(testdata.OrignialUrl, urldata.OrignialUrl);
            Assert.True(Compare(testdata.OutgoingLinks, urldata.OutgoingLinks),nameof(urldata.OutgoingLinks));
            Assert.Equal(testdata.Reputation, urldata.Reputation);
            Assert.Equal(testdata.Statistics, urldata.Statistics);
            Assert.True(Compare(testdata.Tags, urldata.Tags),nameof(urldata.Tags));
            Assert.True(Compare(testdata.TargetedBrand, urldata.TargetedBrand),nameof(urldata.TargetedBrand));
            Assert.Equal(testdata.TimesSubmitted, urldata.TimesSubmitted);
            Assert.Equal(testdata.Title, urldata.Title);
            Assert.Equal(testdata.TotalVotes, urldata.TotalVotes);
            Assert.True(Compare(testdata.Trackers, urldata.Trackers),nameof(urldata.Trackers));

        }
        [Fact]
        public async void Url_EqualsMethod_SameOriginalUrl()
        {
            //Given
            IUrl testdata = VirusTotalLib.MockResponses.PresetUrl();
            //When
            IUrl urldata = await VirusTotalLib.MockResponses.GetUrlFromJson();
            //Then

            Assert.Equal(testdata, urldata);
        }
        [Fact]
        public void Url_EqualsMethod_DifferentObject()
        {
            //Given
            IUrl testdata = VirusTotalLib.MockResponses.PresetUrl();
            //When
            object obj = new Dictionary<object, object>();
            //Then

            Assert.NotEqual(testdata, obj);
        }


        
        private bool Compare(List<string> link1, List<string> link2)
        {
            if (link1.Count != link2.Count) return false;
            var en1 = link1.GetEnumerator();
            var en2 = link2.GetEnumerator();
            while (en1.MoveNext())
            {
                en2.MoveNext();
                if (en1.Current != en2.Current) return false;
            }
            return true;
        }
        private bool Compare(IReadOnlyDictionary<string, VirusTotalLib.VT.ITracker[]> dict, IReadOnlyDictionary<string, VirusTotalLib.VT.ITracker[]> dict2)
        {
            if (dict.Count != dict2.Count) return false;
            var en1 = dict.GetEnumerator();
            var en2 = dict2.GetEnumerator();
            while (en1.MoveNext())
            {
                en2.MoveNext();
                if (en1.Current.Key != en2.Current.Key) return false;
                if (en1.Current.Value.Length != en2.Current.Value.Length) return false;
                for (int i = 0; i < en1.Current.Value.Length; i++)
                {
                    if (!en1.Current.Value[i].Equals(en2.Current.Value[i])) return false;
                }
            }
            return true;
        }
        private bool Compare(IReadOnlyDictionary<string, string> dict, IReadOnlyDictionary<string, string> dict2)
        {
            if (dict.Count != dict2.Count) return false;
            var en1 = dict.GetEnumerator();
            var en2 = dict2.GetEnumerator();
            while (en1.MoveNext())
            {
                en2.MoveNext();
                if (en1.Current.Key != en2.Current.Key || en1.Current.Value != en2.Current.Value) return false;
                
            }
            return true;
        }
        private bool Compare(IReadOnlyDictionary<string,string[]> dict, IReadOnlyDictionary<string, string[]> dict2)
        {
            if (dict.Count != dict2.Count) return false;
            var en1 = dict.GetEnumerator();
            var en2 = dict2.GetEnumerator();
            while (en1.MoveNext())
            {
                en2.MoveNext();
                if (en1.Current.Key != en2.Current.Key) return false;
                if (en1.Current.Value.Length != en2.Current.Value.Length) return false;
                for (int i = 0; i < en1.Current.Value.Length; i++)
                {
                    if (en1.Current.Value[i] != en2.Current.Value[i]) return false;
                }
            }
            return true;
        }
        private bool Compare(IReadOnlyDictionary<string, VirusTotalLib.AV.IUrlAnalysisResult> dict, IReadOnlyDictionary<string, VirusTotalLib.AV.IUrlAnalysisResult> dict2)
        {
            if (dict.Count != dict2.Count) return false;
            var en1 = dict.GetEnumerator();
            var en2 = dict2.GetEnumerator();
            while (en1.MoveNext())
            {
                en2.MoveNext();
                if (en1.Current.Key != en2.Current.Key
                    || !en1.Current.Value.Equals(en2.Current.Value)) return false;
            }
            return true;
        }

    }
}
