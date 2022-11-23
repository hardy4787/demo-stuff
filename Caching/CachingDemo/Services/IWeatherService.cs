using CachingExample.Models;

namespace CachingExample.Services
{
    public interface IWeatherService
    {
        Task<WeatherResponse?> GetCurrentWeatherAsync(string city);
    }
}
