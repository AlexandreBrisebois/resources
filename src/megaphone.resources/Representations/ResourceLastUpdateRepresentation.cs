using Megaphone.Standard.Representations;
using System;
using System.Text.Json.Serialization;

namespace Megaphone.Resources.Representations
{
    public class ResourceLastUpdateRepresentation : Representation
    {
        [JsonPropertyName("is-active")]
        public bool IsActive { get; set; } = false;
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
        [JsonPropertyName("last-updated")]
        public DateTimeOffset LastUpdated { get; set; }
    }
}