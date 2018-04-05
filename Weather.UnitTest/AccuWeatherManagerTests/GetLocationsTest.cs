using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Data;
using Weather.Models;

namespace Weather.AccuWeatherManagerTests.UnitTest
{
    [TestFixture]
    class GetLocationsTest
    {
        private const string ODESSA_RESPONSE_JSON = "[{ \"Version\": 1,\"Key\": \"331122\",\"Type\": \"City\",\"Rank\": 45,\"LocalizedName\": \"Odessa\",\"EnglishName\": \"Odessa\",\"PrimaryPostalCode\": \"79761\",\"Region\": {\"ID\": \"NAM\",\"LocalizedName\": \"North America\",\"EnglishName\": \"North America\"},\"Country\": {\"ID\": \"US\",\"LocalizedName\": \"United States\",\"EnglishName\": \"United States\"},\"AdministrativeArea\": {\"ID\": \"TX\",\"LocalizedName\": \"Texas\",\"EnglishName\": \"Texas\",\"Level\": 1,\"LocalizedType\": \"State\",\"EnglishType\": \"State\",\"CountryID\": \"US\"},\"TimeZone\": {\"Code\": \"CDT\",\"Name\": \"America/Chicago\",\"GmtOffset\": -5,\"IsDaylightSaving\": true,\"NextOffsetChange\": \"2018-11-04T07:00:00Z\"},\"GeoPosition\": {\"Latitude\": 31.846,\"Longitude\": -102.368,\"Elevation\": {\"Metric\": {\"Value\": 887,\"Unit\": \"m\",\"UnitType\": 5},\"Imperial\": {\"Value\": 2909,\"Unit\": \"ft\",\"UnitType\": 0}}},\"IsAlias\": false,\"SupplementalAdminAreas\": [{\"Level\": 2,\"LocalizedName\": \"Ector\",\"EnglishName\": \"Ector\"}],\"DataSets\": [\"Alerts\",\"DailyAirQualityForecast\",\"DailyPollenForecast\",\"ForecastConfidence\",\"MinuteCast\"]},]";
        private Mock<IAccuWeatherService> mock;
        private AccuWeatherManager manager;

        [OneTimeSetUp]
        public void FixtureSetup()
        {
            var locations = JsonConvert.DeserializeObject<List<Location>>(ODESSA_RESPONSE_JSON);
            mock = new Mock<IAccuWeatherService>();
            mock.Setup(d => d.GetLocations("Odessa")).ReturnsAsync(locations);
            manager = new AccuWeatherManager(mock.Object, new Dictionary<string, Object>());
        }

        [Category("AccuWeatherManager GetLocations")]
        [Test]
        public async Task GetLocationsResultCountTest()
        {                   
            var callResult =  await manager.GetLocations("Odessa");
            Assert.AreEqual(1, callResult.Count);
        }

        [Category("AccuWeatherManager GetLocations")]
        [Test]
        public async Task GetLocationsKeyTest()
        {
            var callResult = await manager.GetLocations("Odessa");
            Assert.AreEqual("331122", callResult[0].Key);
        }
    }
}
