using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Data
{
    public class AccuWeatherService : IAccuWeatherService
    {
        private const string GET_LOCATIONS_URL = "http://dataservice.accuweather.com/locations/v1/cities/search?apikey={0}&q={1}";
        private const string GET_CURRENT_CONDITIONS_URL = "http://dataservice.accuweather.com/currentconditions/v1/{0}?apikey={1}";
        private const string API_KEY = "OGlU3Yq1dm6cri1pYH0vsqGOi9jgtNPL";
        HttpClient client;
        public List<CurrentConditions> Conditions { get; private set; }
        public List<Location> Locations { get; private set; }

        public AccuWeatherService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        

        public async Task<List<CurrentConditions>> GetCurrentConditions(int locationKey)
        {
            Uri uri = new Uri(string.Format(GET_CURRENT_CONDITIONS_URL, locationKey, API_KEY));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Conditions = JsonConvert.DeserializeObject<List<CurrentConditions>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Conditions;
        }

        public async Task<List<Location>> GetLocations(string searchText)
        {
            Uri uri = new Uri(string.Format(GET_LOCATIONS_URL, API_KEY, searchText));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Locations = JsonConvert.DeserializeObject<List<Location>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Locations;
        }
    }
}
