// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class DetectedLanguage : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WritePropertyName("iso6391Name");
            writer.WriteStringValue(Iso6391Name);
            writer.WritePropertyName("score");
            writer.WriteNumberValue(Score);
            writer.WriteEndObject();
        }
        internal static DetectedLanguage DeserializeDetectedLanguage(JsonElement element)
        {
            DetectedLanguage result = new DetectedLanguage();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("iso6391Name"))
                {
                    result.Iso6391Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("score"))
                {
                    result.Score = property.Value.GetDouble();
                    continue;
                }
            }
            return result;
        }
    }
}
