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
                AnalysisResult value = JsonSerializer.Deserialize<AnalysisResult>(ref reader, options);
                dictionary.Add(key, value);
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<string, IUrlAnalysisResult> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            foreach (var KeyVal in value)
            {
                writer.WritePropertyName(KeyVal.Key);
                JsonSerializer.Serialize<AnalysisResult>(writer, (AnalysisResult)KeyVal.Value, options);
            }
            writer.WriteEndObject();
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
            switch (value)
            {
                case IFileAnalysisResult.Categories.ConfirmedTimeout:
                    writer.WriteStringValue("confirmed-timeout");
                    break;
                case IFileAnalysisResult.Categories.Failure:
                    writer.WriteStringValue("failure");
                    break;
                case IFileAnalysisResult.Categories.Harmless:
                    writer.WriteStringValue("harmless");
                    break;
                case IFileAnalysisResult.Categories.Malicious:
                    writer.WriteStringValue("malicious");
                    break;
                case IFileAnalysisResult.Categories.Suspicious:
                    writer.WriteStringValue("suspicious");
                    break;
                case IFileAnalysisResult.Categories.TypeUnsupported:
                    writer.WriteStringValue("type-unsupported");
                    break;
                case IFileAnalysisResult.Categories.Undetected:
                    writer.WriteStringValue("undeteced");
                    break;
                default:
                    throw new JsonException();
            }
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
            JsonSerializer.Serialize<Votes>(writer, (Votes)value, options);
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
            for (int i = 0; i < trackers.Length; i++)
            {
                endValue[i] = trackers[i];
            }
            return endValue;
        }
        private Tracker[] ITrackerConverter(ITracker[] trackers)
        {
            Tracker[] endValue = new Tracker[trackers.Length];
            for (int i = 0; i < trackers.Length; i++)
            {
                endValue[i] = (Tracker)trackers[i];
            }
            return endValue;
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<string, ITracker[]> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            foreach (var KeyValue in value)
            {
                writer.WritePropertyName(KeyValue.Key);
                JsonSerializer.Serialize<Tracker[]>(writer, ITrackerConverter(KeyValue.Value), options);
            }
            writer.WriteEndObject();
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
            JsonSerializer.Serialize<AnalysisStatistics>(writer, (AnalysisStatistics)value, options);
        }
    }
}

