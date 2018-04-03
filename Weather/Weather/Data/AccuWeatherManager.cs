using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Data
{
    public class AccuWeatherManager
    {
        IAccuWeatherService restService;

        public AccuWeatherManager(IAccuWeatherService restService)
        {
            this.restService = restService;
        }

        public Task<List<Location>> GetLocations(string searchText)
        {
            return restService.GetLocations(searchText);
        }

        public Task<List<CurrentConditions>> GetCurrentConditions(int locationKey)
        {
            return restService.GetCurrentConditions(locationKey);
        }
    }
}
