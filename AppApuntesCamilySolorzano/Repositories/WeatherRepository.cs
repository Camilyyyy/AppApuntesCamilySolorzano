using AppApuntesCamilySolorzano.Services;
using AppApuntesCamilySolorzano.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppApuntesCamilySolorzano.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly IWeatherApiService _weatherApiService;

        public WeatherRepository(IWeatherApiService weatherApiService)
        {
            _weatherApiService= weatherApiService;
        }

        public async Task<WeatherDisplayModel> GetCurrentWeather(double latitude, double longitude)
        {
            try
            {
                var apiResponse=await _weatherApiService.GetWeatherData(latitude, longitude);
                var weatherData = MapToWeatherData(apiResponse);
                return weatherData;
            }catch (Exception ex) {
                throw new Exception($"Error al obtener datos del clima: {ex.Message}", ex);
            }
        }

        private WeatherDisplayModel MapToWeatherData(WeatherApiResponse response)
        {
            if (response?.Current == null || response?.Units == null)
            {
                throw new ArgumentException("Respuesta de la API inválida");
            }

            return new WeatherDisplayModel
            {
                Timestamp = DateTime.Parse(response.Current.Time),
                Temperature = response.Current.Temperature,
                Humidity = response.Current.RelativeHumidity, 
                Rain = response.Current.Rain,
                TemperatureUnit = response.Units.Temperature,
                HumidityUnit = response.Units.Humidity,
                RainUnit = response.Units.Rain,
                Latitude = response.Latitude,
                Longitude = response.Longitude
            };
        }
    }
}

