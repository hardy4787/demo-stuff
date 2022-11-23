using CachingExample.Models;
using System.Net;

namespace CachingExample.Services
{
    public class WeatherService : IWeatherService
    {
        private const string OpenWeatherApiKey = "0ef56374dd5d93837325b180ea4e0a2d";
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<WeatherResponse?> GetCurrentWeatherAsync(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={OpenWeatherApiKey}";
            var httpClient = _httpClientFactory.CreateClient();

            var weatherResponse = await httpClient.GetAsync(url);
            if (weatherResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            var weather = await weatherResponse.Content.ReadFromJsonAsync<WeatherResponse>();
            return weather;
        }
    }
}
