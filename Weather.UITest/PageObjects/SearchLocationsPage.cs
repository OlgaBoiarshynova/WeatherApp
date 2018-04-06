using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
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
        public override bool IsPageOpen
        {
            get
            {
                return SearchBarElement.Displayed;
            }
        }

        public int GetLocationCount
        {
            get
            {
               //TODO: Add explicit wait here
               return LocationList.Count;
            }
        }
        public SearchLocationsPage(WindowsDriver<WindowsElement> appSession) : base(appSession)
        {
        }

        public void ReturnToMainPage()
        {
            BackToolbarButton.Click();
        }

        public void SearchForLocation(string cityName)
        {
            SearchBarElement.SendKeys(cityName);
            SearchBarElement.FindElementsByClassName("Button")[1].Click();
        }

        public void SelectLocationByIndex(int index)
        {
            LocationList.ElementAt(index).Click();
        }

        protected override void InitializeElements()
        {
            base.InitializeElements();
            SearchBarElement = AppSession.FindElementByAccessibilityId("searchBar");
            LocationList = AppSession.FindElementsByAccessibilityId("locationItem");
            BackToolbarButton = AppSession.FindElementByAccessibilityId("Back");
        }
    }
}
