using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppApuntesCamilySolorzano.Models
{
    public class WeatherApiResponse
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("elevation")]
        public double Elevation { get; set; }

        [JsonPropertyName("current_units")]
        public CurrentUnits Units { get; set; }

        [JsonPropertyName("current")]
        public CurrentWeatherData Current { get; set; }
    }

    public class CurrentUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string Temperature { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public string Humidity { get; set; }

        [JsonPropertyName("rain")]
        public string Rain { get; set; }
    }

    public class CurrentWeatherData
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public double Temperature { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public int RelativeHumidity { get; set; }

        [JsonPropertyName("rain")]
        public double Rain { get; set; }
    }
}
