using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppApuntesCamilySolorzano.Models
{
    internal class WeatherDisplayModel
    {
        public DateTime Timestamp { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public double Rain { get; set; }
        public string TemperatureUnit { get; set; }
        public string HumidityUnit { get; set; }
        public string RainUnit { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
