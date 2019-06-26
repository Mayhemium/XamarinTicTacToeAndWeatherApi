using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TomaszZdebskiApp.Model
{
    public class Weather
    {
        public Temperatures main;
        [JsonProperty("weather")]
        public Desc[] weather;

        [JsonProperty("base")]
        public string asd;
    }
}
