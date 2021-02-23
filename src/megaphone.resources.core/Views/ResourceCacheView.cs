using System.Text.Json.Serialization;

namespace Megaphone.Resources.Core.Views
{
    public class ResourceCacheView
    {
        [JsonPropertyName("display")]
        public string Cache { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}