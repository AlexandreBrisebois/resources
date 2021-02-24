using Megaphone.Standard.Representations;
using System.Text.Json.Serialization;

namespace Megaphone.Resources.Representations
{
    public class ResourceCacheRepresentation : Representation
    {
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
        
        [JsonPropertyName("cache")]
        public string Cache { get; set; } = string.Empty;
    }
}