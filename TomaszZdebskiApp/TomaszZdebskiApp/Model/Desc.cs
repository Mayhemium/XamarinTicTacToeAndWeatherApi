using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TomaszZdebskiApp.Model
{
    public class Desc
    {
        [JsonProperty("description")]
        public string description;
    }
}
