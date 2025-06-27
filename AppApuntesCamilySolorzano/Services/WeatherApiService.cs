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

        public WeatherApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherApiResponse> GetWeatherData(double latitude, double longitude)
        {
            try
            {
                // Formatear las coordenadas con cultura invariante para evitar problemas con separadores decimales
                var latStr = latitude.ToString("F6", System.Globalization.CultureInfo.InvariantCulture);
                var lonStr = longitude.ToString("F6", System.Globalization.CultureInfo.InvariantCulture);

                var apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latStr}&longitude={lonStr}&current=temperature_2m,relative_humidity_2m,rain";

                Console.WriteLine($"API URL: {apiUrl}"); // Para debugging

                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Response: {jsonResponse}"); // Para debugging

                // Configurar JsonSerializer para ser más flexible
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };

                var dataWeather = JsonSerializer.Deserialize<WeatherApiResponse>(jsonResponse, options);

                if (dataWeather == null)
                {
                    throw new Exception("La respuesta de la API es null");
                }

                return dataWeather;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión con la API: {ex.Message}");
            }
            catch (JsonException ex)
            {
                throw new Exception($"Error inesperado al procesar el JSON devuelto por la API: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado: {ex.Message}");
            }
        }
    }
}
