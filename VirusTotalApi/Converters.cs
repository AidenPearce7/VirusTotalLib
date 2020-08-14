using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using VirusTotalLib.AV;
using VirusTotalLib.VT;

namespace VirusTotalLib.Converters
{

    internal class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64());
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.ToUnixTimeSeconds());
        }
    }

    internal class DictAnalysisResult : JsonConverter<Dictionary<string, IUrlAnalysisResult>>
    {
        public override Dictionary<string, IUrlAnalysisResult> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();
            Dictionary<string, IUrlAnalysisResult> dictionary = new Dictionary<string, IUrlAnalysisResult>();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject) return dictionary;
                string key = reader.GetString();
                AnalysisResult value =  JsonSerializer.Deserialize<AnalysisResult>(ref reader, options);
                dictionary.Add(key, value);
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<string, IUrlAnalysisResult> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
    internal class AnalysisResultCategoryConverter : JsonConverter<IFileAnalysisResult.Categories>
    {
        public override IFileAnalysisResult.Categories Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return (reader.GetString()) switch
            {
                "harmless" => IFileAnalysisResult.Categories.Harmless,
                "confirmed-timeout" => IFileAnalysisResult.Categories.ConfirmedTimeout,
                "failure" => IFileAnalysisResult.Categories.Failure,
                "malicious" => IFileAnalysisResult.Categories.Malicious,
                "suspicious" => IFileAnalysisResult.Categories.Suspicious,
                "undeteced" => IFileAnalysisResult.Categories.Undetected,
                "type-unsupported" => IFileAnalysisResult.Categories.TypeUnsupported,
                _ => throw new JsonException(),
            };
        }

        public override void Write(Utf8JsonWriter writer, IFileAnalysisResult.Categories value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
    internal class VotesConverter : JsonConverter<IVotes>
    {
        public override IVotes Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<Votes>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, IVotes value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
    internal class DictTrackers : JsonConverter<Dictionary<string, ITracker[]>>
    {
        public override Dictionary<string, ITracker[]> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();
            Dictionary<string, ITracker[]> dictionary = new Dictionary<string, ITracker[]>();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject) return dictionary;
                string key = reader.GetString();
                ITracker[] value = TrackerConverter(JsonSerializer.Deserialize<Tracker[]>(ref reader, options));
                dictionary.Add(key, value);
            }
            throw new JsonException();
        }
        private ITracker[] TrackerConverter(Tracker[] trackers)
        {
            ITracker[] endValue = new ITracker[trackers.Length];
            for (int i =0;i<trackers.Length;i++)
            {
                endValue[i] = trackers[i];
            }
            return endValue;
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<string, ITracker[]> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
    internal class StatisticsConverter : JsonConverter<IUrlAnalysisStatistics>
    {
        public override IUrlAnalysisStatistics Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<AnalysisStatistics>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, IUrlAnalysisStatistics value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}

