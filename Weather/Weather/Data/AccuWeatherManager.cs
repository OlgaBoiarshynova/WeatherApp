using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Data
{
    public class AccuWeatherManager
    {
        IAccuWeatherService RestService { get; set; }
        private List<Location> locationList;
        public ObservableCollection<LocationWeatherInfo> ConditionsList { get; private set; }

        private Dictionary<string, LocationWeatherInfo> locationWeather;
        public Dictionary<string, LocationWeatherInfo> LocationWeather
        {
            get
            {
                if (locationWeather == null) locationWeather = new Dictionary<string, LocationWeatherInfo>();
                return locationWeather;
            }
            set { }
        }

        public AccuWeatherManager(IAccuWeatherService restService)
        {
            this.RestService = restService;
            ConditionsList = new ObservableCollection<LocationWeatherInfo>();
        }

        public Task<List<Location>> GetLocations(string searchText)
        {
            return RestService.GetLocations(searchText);
        }

        public Task<List<CurrentConditions>> GetCurrentConditions(string locationKey)
        {
            return RestService.GetCurrentConditions(locationKey);
        }

        public async void LoadConditions()
        {
            ConditionsList.Clear();
            foreach (string key in LocationWeather.Keys)
            {
                var condition = await RestService.GetCurrentConditions(key);                
                LocationWeather[key].WeatherConditions = condition.ElementAt(0);
                ConditionsList.Add(LocationWeather[key]);
            }

        }

        internal void addLocation(Location location)
        {
            var locationInfo = new LocationWeatherInfo()
            {
                Location = location
            };
            LocationWeather.Add(location.Key, locationInfo);
            LoadConditions();
        }
    }
}
