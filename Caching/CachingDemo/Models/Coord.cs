using System.Text.Json.Serialization;

namespace CachingExample.Models
{
    public class Coord
    {
        [JsonPropertyName("lon")] public double Lon { get; set; }

        [JsonPropertyName("lat")] public double Lat { get; set; }
    }
}
