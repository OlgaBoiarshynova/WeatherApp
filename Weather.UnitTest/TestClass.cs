using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Weather.UnitTest
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            var mock = new Mock<HttpClient>();
            mock.Setup(cl => cl.GetAsync("http://dataservice.accuweather.com/locations/v1/cities/search?apikey=OGlU3Yq1dm6cri1pYH0vsqGOi9jgtNPL&q=London")).ReturnsAsync(new HttpResponseMessage());
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }
    }
}
