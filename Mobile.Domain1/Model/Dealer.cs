using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Domain1.Model
{
    [ExcludeFromCodeCoverage]
    public class Weather
    {
        public class WeatherForecast
        {
            public DateTime Date { get; set; }

            public int TemperatureC { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

            public string? Summary { get; set; }
        }
    }
}
