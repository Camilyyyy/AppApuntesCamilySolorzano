using Microsoft.Extensions.Logging;
using AppApuntesCamilySolorzano.Services;
using AppApuntesCamilySolorzano.Repositories;
using AppApuntesCamilySolorzano.Views;
using AppApuntesCamilySolorzano.ViewModels;

namespace AppApuntesCamilySolorzano
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Registrar HttpClient
            builder.Services.AddHttpClient<IWeatherApiService, WeatherApiService>();

            // Registrar servicios de infraestructura
            builder.Services.AddSingleton<IWeatherApiService, WeatherApiService>();

            // Registrar repositorios
            builder.Services.AddSingleton<IWeatherRepository, WeatherRepository>();

            // Registrar ViewModels
            builder.Services.AddTransient<WeatherViewModel>();

            // Registrar páginas
            builder.Services.AddTransient<WeatherPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}