using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppApuntesCamilySolorzano.Models
{
    internal class WeatherDisplayModel
    {
        public string Time { get; set; }           
        public string Temperature { get; set; }    
        public string Humidity { get; set; }       
        public string Rain { get; set; }          

        public string LocationText { get; set; }
        public string WeatherIcon { get; set; }
        public bool IsRaining { get; set; }
    }
}
