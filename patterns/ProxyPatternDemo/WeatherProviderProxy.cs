using ProxyPattern.Library;
using ProxyPatternDemo;

namespace ProxyPattern.Demo
{
    public class WeatherProviderProxy : IWeatherProvider
    {
        private readonly IWeatherProvider _weatherProvider;

        public WeatherProviderProxy(IWeatherProvider weatherProvider)
        {
            _weatherProvider = weatherProvider;
        }

        public IEnumerable<WeatherForecast> Get(int totalCount)
        {
            if (totalCount < 2 || totalCount > 5)
                throw new ArgumentOutOfRangeException("totalCount", "Total should be between 2 and 5");

            return _weatherProvider.Get(totalCount);
        }
    }
}
