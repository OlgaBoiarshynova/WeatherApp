using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Weather.UITest.PageObjects
{
    class SearchLocationsPage : BasePage
    {
        WindowsElement SearchBarElement { get; set; }
        IReadOnlyCollection<WindowsElement> LocationList { get; set; }
        WindowsElement BackToolbarButton { get; set; }

        public SearchLocationsPage(WindowsDriver<WindowsElement> appSession) : base (appSession)
        {
                    
        }

        public void ReturnToMainPage() {
            BackToolbarButton.Click();
        }

        public void SearchForLocation(string cityName)
        {
            SearchBarElement.SendKeys(cityName + Keys.Enter);
        }

        protected override void InitializeElements()
        {
            SearchBarElement = AppSession.FindElementByAccessibilityId("searchBar");
            LocationList = AppSession.FindElementsByAccessibilityId("searchBar");
            BackToolbarButton = AppSession.FindElementByAccessibilityId("Back");
        }
    }
}
