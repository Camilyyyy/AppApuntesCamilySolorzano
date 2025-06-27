

namespace AppApuntesCamilySolorzano.Views;
using AppApuntesCamilySolorzano.ViewModels;

public partial class WeatherPage : ContentPage
{
	public WeatherPage(WeatherViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}