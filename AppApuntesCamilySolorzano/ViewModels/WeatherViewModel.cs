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

        private string _hora;
        private double _temperatura;
        private int _humedad;
        private double _lluvia;
        private string _unidadTemperatura;
        private string _unidadHumedad;
        private string _unidadLluvia;
        public WeatherViewModel(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;

            LoadWeatherCommand = new Command(async () => await LoadCurrentWeatherData());

        }

        public string Hora
        {
            get => _hora;
            set
            {
                _hora = value;
                OnPropertyChanged();
            }
        }

        public double Temperatura
        {
            get => _temperatura;
            set
            {
                _temperatura = value;
                OnPropertyChanged();
            }
        }

        public int Humedad
        {
            get => _humedad;
            set
            {
                _humedad = value;
                OnPropertyChanged();
            }
        }

        public double Lluvia
        {
            get => _lluvia;
            set
            {
                _lluvia = value;
                OnPropertyChanged();
            }
        }

        public string UnidadTemperatura
        {
            get => _unidadTemperatura;
            set
            {
                _unidadTemperatura = value;
                OnPropertyChanged();
            }
        }

        public string UnidadHumedad
        {
            get => _unidadHumedad;
            set
            {
                _unidadHumedad = value;
                OnPropertyChanged();
            }
        }

        public string UnidadLluvia
        {
            get => _unidadLluvia;
            set
            {
                _unidadLluvia = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadWeatherCommand { get; }

        private async Task LoadCurrentWeatherData()
        {
            try
            {


                var weatherData = await _weatherRepository.GetCurrentWeather(46.94, 7.44);

                UpdateWeatherDisplay(weatherData);
            }
            catch (Exception ex)
            {
               
            }
        }

        private void UpdateWeatherDisplay(WeatherDisplayModel weatherData)
        {
            Hora = weatherData.Timestamp.ToString("dd/MM/yyyy HH:mm");
            Temperatura = weatherData.Temperature;
            Humedad = weatherData.Humidity;
            Lluvia = weatherData.Rain;
            UnidadTemperatura = weatherData.TemperatureUnit;
            UnidadHumedad = weatherData.HumidityUnit;
            UnidadLluvia = weatherData.RainUnit;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

