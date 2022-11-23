using CachingExample.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CachingExample.Services
{
    public class CachedWeatherService : IWeatherService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IWeatherService _weatherService;

        public CachedWeatherService(IMemoryCache memoryCache, IWeatherService weatherService)
        {
            _memoryCache = memoryCache;
            _weatherService = weatherService;
        }

        public async Task<WeatherResponse?> GetCurrentWeatherAsync(string city)
        {
            return await _memoryCache.GetOrCreateAsync(city,
                async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                    return await _weatherService.GetCurrentWeatherAsync(entry.Key.ToString()!);
                });
        }
    }
}
