using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Weather.UITest.PageObjects;

namespace Weather.UITest.Tests
{
    [TestFixture]
    public class SearchLocationPageTests : BaseTest
    {
        [Category("SearchLocationPageTests")]
        [Test]
        public void BackNavigationTest()
        {
            MainPage mainPage = new MainPage(session);
            mainPage.OpenSearchLocationPage();
            SearchLocationsPage searchLocationPage = new SearchLocationsPage(session);
            searchLocationPage.ReturnToMainPage();
            Assert.IsTrue(mainPage.IsPageOpen);
        }

        [Category("SearchLocationPageTests")]
        [Test]
        public void SearchForLocationTest()
        {
            MainPage mainPage = new MainPage(session);
            mainPage.OpenSearchLocationPage();
            SearchLocationsPage searchLocationPage = new SearchLocationsPage(session);
            searchLocationPage.SearchForLocation("London");
            int actualCount= searchLocationPage.GetLocationCount;           
            Assert.AreEqual(30, searchLocationPage.GetLocationCount);
        }

    }
}
