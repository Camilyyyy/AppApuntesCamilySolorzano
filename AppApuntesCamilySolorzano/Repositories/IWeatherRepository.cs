using AppApuntesCamilySolorzano.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppApuntesCamilySolorzano.Repositories
{
    public interface IWeatherRepository
    {
        Task<WeatherDisplayModel> GetCurrentWeather(double latitude, double longitude);
    }
}
