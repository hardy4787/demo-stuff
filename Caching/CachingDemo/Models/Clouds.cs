using System.Text.Json.Serialization;

namespace CachingExample.Models
{
    public class Clouds
    {
        [JsonPropertyName("all")] public int All { get; set; }
    }
}
