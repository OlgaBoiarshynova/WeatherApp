using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.UITest.PageObjects;

namespace Weather.UITest.Tests
{
    [TestFixture]
    public class End2EndTests : BaseTest
    {
        [Test]
        [Category("End2EndTests")]
        public void TestMethod()
        {
            MainPage mainPage = new MainPage(session);
            mainPage.OpenSearchLocationPage();
            SearchLocationsPage searchPage = new SearchLocationsPage(session);
            searchPage.SearchForLocation("New York");
            searchPage.ReturnToMainPage();
            //TODO: Add more actions and asserts

        }
    }
}
