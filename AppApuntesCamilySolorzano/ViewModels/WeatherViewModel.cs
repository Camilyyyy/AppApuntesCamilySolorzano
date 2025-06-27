using AppApuntesCamilySolorzano.Models;
using AppApuntesCamilySolorzano.Repositories;
using AppApuntesCamilySolorzano.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;



namespace AppApuntesCamilySolorzano.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private readonly IWeatherRepository _weatherRepository;
        private WeatherDisplayModel _currentWeather;
        private bool _isLoading;
        private string _errorMessage = string.Empty;

        public WeatherViewModel(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
            _currentWeather = new WeatherDisplayModel();

            // Inicializar comando
            UpdateWeatherCommand = new Command(async () => await UpdateWeatherAsync());
        }

        #region Properties

        public WeatherDisplayModel CurrentWeather
        {
            get => _currentWeather;
            set
            {
                _currentWeather = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FormattedTime));
                OnPropertyChanged(nameof(FormattedTemperature));
                OnPropertyChanged(nameof(FormattedHumidity));
                OnPropertyChanged(nameof(FormattedRain));
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        // Propiedades formateadas para la UI
        public string FormattedTime => CurrentWeather?.Timestamp.ToString("HH:mm") ?? "--:--";
        public string FormattedTemperature => CurrentWeather != null ?
            $"{CurrentWeather.Temperature:F1}{CurrentWeather.TemperatureUnit}" : "0°C";
        public string FormattedHumidity => CurrentWeather != null ?
            $"{CurrentWeather.Humidity:F0}{CurrentWeather.HumidityUnit}" : "0%";
        public string FormattedRain => CurrentWeather != null ?
            $"{CurrentWeather.Rain:F1}{CurrentWeather.RainUnit}" : "0mm";

        #endregion

        #region Commands

        public ICommand UpdateWeatherCommand { get; }

        #endregion

        #region Methods

        private async Task UpdateWeatherAsync()
        {
            try
            {
                IsLoading = true;
                ErrorMessage = string.Empty;

                Console.WriteLine("Iniciando actualización del clima...");

                // Obtener ubicación actual
                var location = await GetCurrentLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Ubicación obtenida: Lat={location.Latitude}, Lon={location.Longitude}");

                    // Obtener datos del clima
                    var weatherData = await _weatherRepository.GetCurrentWeather(
                        location.Latitude,
                        location.Longitude);

                    CurrentWeather = weatherData;
                    Console.WriteLine("Datos del clima obtenidos exitosamente");
                }
                else
                {
                    ErrorMessage = "No se pudo obtener la ubicación";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
                Console.WriteLine($"Error en UpdateWeatherAsync: {ex}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task<Location?> GetCurrentLocationAsync()
        {
            try
            {
                // Verificar permisos de ubicación
                var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                if (status != PermissionStatus.Granted)
                {
                    ErrorMessage = "Se requieren permisos de ubicación";
                    // Usar coordenadas de Quito por defecto
                    Console.WriteLine("Permisos de ubicación denegados, usando Quito por defecto");
                    return new Location(-0.1807, -78.4678);
                }

                // Obtener ubicación actual
                var request = new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(10)
                };

                var location = await Geolocation.GetLocationAsync(request);

                if (location == null)
                {
                    Console.WriteLine("No se pudo obtener ubicación, usando Quito por defecto");
                    return new Location(-0.1807, -78.4678);
                }

                return location;
            }
            catch (Exception ex)
            {
                // Si falla, usar coordenadas de Quito por defecto
                Console.WriteLine($"Error obteniendo ubicación: {ex.Message}");
                ErrorMessage = $"Usando ubicación por defecto. Error: {ex.Message}";
                return new Location(-0.1807, -78.4678); // Quito, Ecuador
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

