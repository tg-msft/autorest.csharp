// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class BlobPrefix : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }
        internal static BlobPrefix DeserializeBlobPrefix(JsonElement element)
        {
            BlobPrefix result = new BlobPrefix();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "BlobPrefix");
            writer.WriteStartElement("Name");
            writer.WriteValue(Name);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        internal static BlobPrefix DeserializeBlobPrefix(XElement element)
        {
            BlobPrefix result = default;
            result = new BlobPrefix(); string value = default;
            var name = element.Element("Name");
            if (name != null)
            {
                value = (string)name;
            }
            result.Name = value;
            return result;
        }
    }
}
