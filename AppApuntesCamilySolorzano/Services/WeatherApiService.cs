using AppApuntesCamilySolorzano.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppApuntesCamilySolorzano.Services
{
    public class WeatherApiService : IWeatherApiService
    {
        private readonly HttpClient _httpClient;
        private const string apiurl = "https://api.open-meteo.com/v1/forecast?latitude=46.9481&longitude=7.4474&current=temperature_2m,relative_humidity_2m,rain";

        public WeatherApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ;
        }
        public async Task<WeatherApiResponse> GetWeatherData(double latitude, double longitude)
        {
            try
            {
                var response = await _httpClient.GetAsync(apiurl);
                response.EnsureSuccessStatusCode();
                var jsonresponse = await response.Content.ReadAsStringAsync();
                var dataWeather = JsonSerializer.Deserialize<WeatherApiResponse>(jsonresponse);
                return dataWeather;
            }catch (HttpRequestException ex) {
                throw new Exception($"Error de conexión con la API: {ex.Message}");
            }
            catch (JsonException ex) {
                throw new Exception($"Error inesperado al procesar el json devuelto por la api: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado: {ex.Message}");
            }
        }
    }
}
