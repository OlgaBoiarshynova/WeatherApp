using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Data
{
    public interface IAccuWeatherService
    {
        Task<List<Location>> GetLocations(string searchText);
        Task<List<CurrentConditions>> GetCurrentConditions(int locationKey);
    }
}
