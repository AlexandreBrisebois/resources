using System.Text.Json.Serialization;

namespace Megaphone.Resources.Core.Views
{
    public class ResourceCacheView
    {
        [JsonPropertyName("cache")]
        public string Cache { get; set; } = string.Empty;

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        public static readonly ResourceCacheView Empty = new();
    }
}