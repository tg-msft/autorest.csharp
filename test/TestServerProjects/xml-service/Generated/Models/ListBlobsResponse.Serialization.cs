// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class ListBlobsResponse : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("ServiceEndpoint");
            writer.WriteStringValue(ServiceEndpoint);
            writer.WritePropertyName("ContainerName");
            writer.WriteStringValue(ContainerName);
            writer.WritePropertyName("Prefix");
            writer.WriteStringValue(Prefix);
            writer.WritePropertyName("Marker");
            writer.WriteStringValue(Marker);
            writer.WritePropertyName("MaxResults");
            writer.WriteNumberValue(MaxResults);
            writer.WritePropertyName("Delimiter");
            writer.WriteStringValue(Delimiter);
            writer.WritePropertyName("Blobs");
            writer.WriteObjectValue(Blobs);
            writer.WritePropertyName("NextMarker");
            writer.WriteStringValue(NextMarker);
            writer.WriteEndObject();
        }
        internal static ListBlobsResponse DeserializeListBlobsResponse(JsonElement element)
        {
            ListBlobsResponse result = new ListBlobsResponse();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ServiceEndpoint"))
                {
                    result.ServiceEndpoint = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ContainerName"))
                {
                    result.ContainerName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Prefix"))
                {
                    result.Prefix = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Marker"))
                {
                    result.Marker = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("MaxResults"))
                {
                    result.MaxResults = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("Delimiter"))
                {
                    result.Delimiter = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Blobs"))
                {
                    result.Blobs = Blobs.DeserializeBlobs(property.Value);
                    continue;
                }
                if (property.NameEquals("NextMarker"))
                {
                    result.NextMarker = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "EnumerationResults");
            writer.WriteStartAttribute("ServiceEndpoint");
            writer.WriteValue(ServiceEndpoint);
            writer.WriteEndAttribute();
            writer.WriteStartAttribute("ContainerName");
            writer.WriteValue(ContainerName);
            writer.WriteEndAttribute();
            writer.WriteStartElement("Prefix");
            writer.WriteValue(Prefix);
            writer.WriteEndElement();
            writer.WriteStartElement("Marker");
            writer.WriteValue(Marker);
            writer.WriteEndElement();
            writer.WriteStartElement("MaxResults");
            writer.WriteValue(MaxResults);
            writer.WriteEndElement();
            writer.WriteStartElement("Delimiter");
            writer.WriteValue(Delimiter);
            writer.WriteEndElement();
            writer.WriteObjectValue(Blobs, "Blobs");
            writer.WriteStartElement("NextMarker");
            writer.WriteValue(NextMarker);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        internal static ListBlobsResponse DeserializeListBlobsResponse(XElement element)
        {
            ListBlobsResponse result = default;
            result = new ListBlobsResponse(); var serviceEndpoint = element.Attribute("ServiceEndpoint");
            if (serviceEndpoint != null)
            {
                result.ServiceEndpoint = (string)serviceEndpoint;
            }
            var containerName = element.Attribute("ContainerName");
            if (containerName != null)
            {
                result.ContainerName = (string)containerName;
            }
            string value = default;
            var prefix = element.Element("Prefix");
            if (prefix != null)
            {
                value = (string)prefix;
            }
            result.Prefix = value;
            string value0 = default;
            var marker = element.Element("Marker");
            if (marker != null)
            {
                value0 = (string)marker;
            }
            result.Marker = value0;
            int value1 = default;
            var maxResults = element.Element("MaxResults");
            if (maxResults != null)
            {
                value1 = (int)maxResults;
            }
            result.MaxResults = value1;
            string value2 = default;
            var delimiter = element.Element("Delimiter");
            if (delimiter != null)
            {
                value2 = (string)delimiter;
            }
            result.Delimiter = value2;
            Blobs value3 = default;
            var blobs = element.Element("Blobs");
            if (blobs != null)
            {
                value3 = Blobs.DeserializeBlobs(blobs);
            }
            result.Blobs = value3;
            string value4 = default;
            var nextMarker = element.Element("NextMarker");
            if (nextMarker != null)
            {
                value4 = (string)nextMarker;
            }
            result.NextMarker = value4;
            return result;
        }
    }
}
