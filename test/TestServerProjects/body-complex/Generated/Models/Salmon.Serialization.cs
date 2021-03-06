// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class Salmon : Azure.Core.IUtf8JsonSerializable
    {
        void Azure.Core.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Location != null)
            {
                writer.WritePropertyName("location");
                writer.WriteStringValue(Location);
            }
            if (Iswild != null)
            {
                writer.WritePropertyName("iswild");
                writer.WriteBooleanValue(Iswild.Value);
            }
            writer.WritePropertyName("fishtype");
            writer.WriteStringValue(Fishtype);
            if (Species != null)
            {
                writer.WritePropertyName("species");
                writer.WriteStringValue(Species);
            }
            writer.WritePropertyName("length");
            writer.WriteNumberValue(Length);
            if (Siblings != null)
            {
                writer.WritePropertyName("siblings");
                writer.WriteStartArray();
                foreach (var item in Siblings)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static body_complex.Models.Salmon DeserializeSalmon(System.Text.Json.JsonElement element)
        {
            if (element.TryGetProperty("fishtype", out System.Text.Json.JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "smart_salmon": return body_complex.Models.SmartSalmon.DeserializeSmartSalmon(element);
                }
            }
            body_complex.Models.Salmon result = new body_complex.Models.Salmon();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("location"))
                {
                    if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Location = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("iswild"))
                {
                    if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Iswild = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("fishtype"))
                {
                    result.Fishtype = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"))
                {
                    if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Species = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("length"))
                {
                    result.Length = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("siblings"))
                {
                    if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Siblings = new System.Collections.Generic.List<body_complex.Models.Fish>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Siblings.Add(body_complex.Models.Fish.DeserializeFish(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
