using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomaszZdebskiApp.View;
using Xamarin.Forms;

namespace TomaszZdebskiApp.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        public Command NavigateTTT { get; private set; }
        public Command NavigateWea { get; private set; }
        private INavigation Navigation;

        public MainPageViewModel(INavigation nav)
        {
            NavigateTTT = new Command(async() => await NavigateT());
            NavigateWea = new Command(async () => await NavigateWeather());
            Navigation = nav;
        }

        private async Task NavigateT()
        {
            await Navigation.PushAsync(new TicTacToePage());
        }

        private async Task NavigateWeather()
        {
            await Navigation.PushAsync(new WeatherPage());
        }
    }
}
