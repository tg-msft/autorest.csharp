// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class Entity : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("text");
            writer.WriteStringValue(Text);
            writer.WritePropertyName("type");
            writer.WriteStringValue(Type);
            if (SubType != null)
            {
                writer.WritePropertyName("subType");
                writer.WriteStringValue(SubType);
            }
            writer.WritePropertyName("offset");
            writer.WriteNumberValue(Offset);
            writer.WritePropertyName("length");
            writer.WriteNumberValue(Length);
            writer.WritePropertyName("score");
            writer.WriteNumberValue(Score);
            writer.WriteEndObject();
        }
        internal static Entity DeserializeEntity(JsonElement element)
        {
            Entity result = new Entity();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("text"))
                {
                    result.Text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    result.Type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("subType"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.SubType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("offset"))
                {
                    result.Offset = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("length"))
                {
                    result.Length = property.Value.GetInt32();
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
