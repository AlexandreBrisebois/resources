using Megaphone.Standard.Representations;
using System;
using System.Text.Json.Serialization;

namespace Megaphone.Resources.Representations
{
    public class ResourceLastUpdateRepresentation : Representation
    {
        [JsonPropertyName("last-updated")]
        public DateTimeOffset LastUpdated { get; set; }
    }
}