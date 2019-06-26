using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TomaszZdebskiApp.Model;
using Xamarin.Forms;

namespace TomaszZdebskiApp.ViewModel
{
    class WeatherPageViewModel : BaseViewModel
    {
        private string key = "aca9a701c39cbae0d3c6b55ccf8eb33e";
        private string _city = "";
        private float _temp = 0;
        private float _temp_min = 0;
        private float _temp_max = 0;
        private string _desc = "a";
        private bool _vis = false;
        private string _color = "white";
        private HttpClient _client;

        public Command GetWeather { get; private set; }
        public string City { get => _city; set { _city = value; RaisePropertyChanged("City"); } }
        public float Temp { get => _temp; set { _temp = value; RaisePropertyChanged("Temp"); } }
        public float Temp_min { get => _temp_min; set { _temp_min = value; RaisePropertyChanged("Temp_min"); } }
        public float Temp_max { get => _temp_max; set { _temp_max = value; RaisePropertyChanged("Temp_max"); } }
        public string Desc { get => _desc; set { _desc = value; RaisePropertyChanged("Desc"); } }
        public bool Vis { get => _vis; set { _vis = value; RaisePropertyChanged("Vis"); } }
        public string Color { get => _color; set { _color = value; RaisePropertyChanged("Color"); } }


        public WeatherPageViewModel()
        {
            _client = new HttpClient();
            GetWeather = new Command(async() => await GetWeatherFunc());
        }

        public async Task GetWeatherFunc()
        {
            string uri = "http://api.openweathermap.org/data/2.5/weather?q="+City+"&appid="+key+"&units=metric";
            var response = await _client.GetAsync(uri);
            string responseCont = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                Weather res = JsonConvert.DeserializeObject<Weather>(responseCont);
                Desc = res.weather[0].description;
                Temp = res.main.temp;
                Temp_min = res.main.temp_min;
                Temp_max = res.main.temp_max;
                Vis = true;
                Color = "white";
            }
            else
            {
                Vis = false;
                Color = "red";
            }
        }

    }
}
