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
    class GetCurrentConditionsTest
    {
        private const string CONDITIONS_RESPONSE_JSON = "[{\"LocalObservationDateTime\": \"2018-04-03T15:15:00-05:00\",\"EpochTime\": 1522786500,\"WeatherText\": \"Light rain\",\"WeatherIcon\": 12,\"IsDayTime\": true,\"Temperature\": {\"Metric\": {\"Value\": 23.9,\"Unit\": \"C\",\"UnitType\": 17},\"Imperial\": {\"Value\": 75,\"Unit\": \"F\",\"UnitType\": 18}},\"MobileLink\": \"http://m.accuweather.com/en/us/odessa-tx/79761/current-weather/331122?lang=en-us\",\"Link\": \"http://www.accuweather.com/en/us/odessa-tx/79761/current-weather/331122?lang=en-us\"}]";
        private Mock<IAccuWeatherService> mock;
        private AccuWeatherManager manager;

        [OneTimeSetUp]
        public void FixtureSetup()
        {
            var conditions = JsonConvert.DeserializeObject<List<CurrentConditions>>(CONDITIONS_RESPONSE_JSON);
            mock = new Mock<IAccuWeatherService>();
            mock.Setup(d => d.GetCurrentConditions("331122")).ReturnsAsync(conditions);
            manager = new AccuWeatherManager(mock.Object, new Dictionary<string, Object>());
        }

        [Category("AccuWeatherManager GetCurrentConditions")]
        [Test]
        public async Task GetCurrentConditionsResultCountTest()
        {
            var callResult = await manager.GetCurrentConditions("331122");
            Assert.AreEqual(1, callResult.Count);
        }

        [Category("AccuWeatherManager GetCurrentConditions")]
        [Test]
        public async Task GetCurrentConditionsWeatherTextTest()
        {
            var callResult = await manager.GetCurrentConditions("331122");
            Assert.AreEqual("Light rain", callResult[0].WeatherText);
        }
        //		Description	"Light rain (23,9℃ / 75℉) | Observed at 03.04.2018 23:15:00"	string

    }
}
