using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    public class CurrentConditions
    {
        public DateTime LocalObservationDateTime { get; set; }
        public int EpochTime { get; set; }
        public string WeatherText { get; set; }
        public int WeatherIcon { get; set; }
        public bool IsDayTime { get; set; }
        public Temperature Temperature { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
        public string Description
        {
            get
            {
                return String.Format("{0} ({1}℃ / {2}℉) | Observed at {3}", WeatherText, Temperature.Metric.Value, Temperature.Imperial.Value, LocalObservationDateTime.ToString());
            }
        }

    }
}
