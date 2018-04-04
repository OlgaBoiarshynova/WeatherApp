using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    public class LocationWeatherInfo
    {
        public Location Location { get; set; }
        public CurrentConditions WeatherConditions { get; set; }
        public string Description
        {
            get
            {
                return String.Format("City: {0} | Weather: {1}", Location.Description, WeatherConditions.Description);
            }
        }
    }
}
