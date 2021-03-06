// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class LanguageInput : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            writer.WritePropertyName("text");
            writer.WriteStringValue(Text);
            if (CountryHint != null)
            {
                writer.WritePropertyName("countryHint");
                writer.WriteStringValue(CountryHint);
            }
            writer.WriteEndObject();
        }
        internal static LanguageInput DeserializeLanguageInput(JsonElement element)
        {
            LanguageInput result = new LanguageInput();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    result.Id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("text"))
                {
                    result.Text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("countryHint"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.CountryHint = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
