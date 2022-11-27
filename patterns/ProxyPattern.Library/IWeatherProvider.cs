using ProxyPatternDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Library
{
    public interface IWeatherProvider
    {
        IEnumerable<WeatherForecast> Get(int totalCount);
    }
}
