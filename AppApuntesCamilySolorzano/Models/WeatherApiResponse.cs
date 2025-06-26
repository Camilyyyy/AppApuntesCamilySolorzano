using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppApuntesCamilySolorzano.Models
{
    public class WeatherApiResponse
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("elevation")]
        public double Elevation { get; set; }

        [JsonProperty("current_units")]
        public CurrentUnits Units { get; set; }

        [JsonProperty("current")]
        public CurrentWeatherData Current { get; set; }
    }

    public class CurrentUnits
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("temperature_2m")]
        public string Temperature { get; set; }

        [JsonProperty("relative_humidity_2m")]
        public string Humidity { get; set; }

        [JsonProperty("rain")]
        public string Rain { get; set; }
    }

    public class CurrentWeatherData
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("temperature_2m")]
        public double Temperature { get; set; }

        [JsonProperty("relative_humidity_2m")]
        public int RelativeHumidity { get; set; }

        [JsonProperty("rain")]
        public double Rain { get; set; }
    }
}
