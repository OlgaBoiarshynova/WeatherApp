using Newtonsoft.Json;
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
            if (App.Current.Properties.ContainsKey("locations"))
            {
                var locationsJson = App.Current.Properties["locations"] as string;
                var locations = JsonConvert.DeserializeObject<List<LocationWeatherInfo>>(locationsJson);
                foreach(LocationWeatherInfo item in locations)
                {
                    LocationWeather.Add(item.Location.Key, item);
                    ConditionsList.Add(item);
                }
            }
        }

        public Task<List<Location>> GetLocations(string searchText)
        {
            return RestService.GetLocations(searchText);
        }

        public Task<List<CurrentConditions>> GetCurrentConditions(string locationKey)
        {
            return RestService.GetCurrentConditions(locationKey);
        }

        internal void AddLocation(Location location)
        {
            if (!LocationWeather.ContainsKey(location.Key))
            {
                var locationInfo = new LocationWeatherInfo()
                {
                    Location = location
                };
                LocationWeather.Add(location.Key, locationInfo);
                LoadConditions();
            }
        }

        internal void RemoveLocation(string keyToRemove)
        {
            ConditionsList.Remove(LocationWeather[keyToRemove]);
            LocationWeather.Remove(keyToRemove);
            SaveLocations(LocationWeather.Values.ToList());
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
            SaveLocations(LocationWeather.Values.ToList());
        }

        private void SaveLocations(List<LocationWeatherInfo> list)
        {
            string json = JsonConvert.SerializeObject(list);
            App.Current.Properties["locations"] = json;
        }
    }
}
