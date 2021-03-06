// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml;

namespace Azure.Core
{
    internal static class JsonElementExtensions
    {
        public static object? GetObject(in this JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.String:
                    return element.GetString();
                case JsonValueKind.Number:
                    if (element.TryGetInt32(out var value))
                    {
                        return value;
                    }
                    return element.GetDouble();
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.False:
                    return false;
                case JsonValueKind.Null:
                    return null;
                case JsonValueKind.Object:
                    var dictionary = new Dictionary<string, object?>();
                    foreach (JsonProperty jsonProperty in element.EnumerateObject())
                    {
                        dictionary.Add(jsonProperty.Name, jsonProperty.Value.GetObject());
                    }
                    return dictionary;
                case JsonValueKind.Array:
                    var list = new List<object?>();
                    foreach (JsonElement item in element.EnumerateArray())
                    {
                        list.Add(item.GetObject());
                    }
                    return list.ToArray();
                default:
                    throw new NotSupportedException("Not supported value kind " + element.ValueKind);
            }
        }

        public static byte[] GetBytesFromBase64(in this JsonElement element, string format) => format switch
        {
            "U" => TypeFormatters.FromBase64UrlString(element.GetString()),
            _ => throw new ArgumentException("Format is not supported", nameof(format))
        };

        public static DateTimeOffset GetDateTimeOffset(in this JsonElement element, string format) => format switch
        {
            "D" => element.GetDateTimeOffset(),
            "S" => DateTimeOffset.Parse(element.GetString()),
            "R" => DateTimeOffset.Parse(element.GetString()),
            "U" => DateTimeOffset.FromUnixTimeSeconds(element.GetInt64()),
            _ => throw new ArgumentException("Format is not supported", nameof(format))
        };

        public static TimeSpan GetTimeSpan(in this JsonElement element, string format) => format switch
        {
            "P" => XmlConvert.ToTimeSpan(element.GetString()),
            _ => throw new ArgumentException("Format is not supported", nameof(format))
        };
    }
}
