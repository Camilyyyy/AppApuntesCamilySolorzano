using AppApuntesCamilySolorzano.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppApuntesCamilySolorzano.Services
{
    public interface IWeatherApiService
    {
        Task<WeatherApiResponse> GetWeatherData (double latitude, double longitude);
    }
}
