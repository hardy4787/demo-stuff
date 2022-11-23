using System.Text.Json.Serialization;

namespace CachingExample.Models
{
    public class Weather
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }

        [JsonPropertyName("icon")] public string Icon { get; set; }
    }
}
