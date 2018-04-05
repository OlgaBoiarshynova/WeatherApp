using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.UITest.PageObjects
{
    class MainPage : BasePage
    {
        
        WindowsElement AddButton { get; set; }
        IReadOnlyCollection<WindowsElement> WeatherConditionsList { get; set; }
        WindowsElement RefreshButton { get; set; }

        public MainPage(WindowsDriver<WindowsElement> appSession) : base (appSession)
        {

        }

        public void OpenSearchLocationPage()
        {
            AddButton.Click();
        }

        public void RefreshWeatherConditions()
        {
            RefreshButton.Click();
        }

        protected override void InitializeElements()
        {
            AddButton = AppSession.FindElementByAccessibilityId("addButton");
            RefreshButton = AppSession.FindElementByAccessibilityId("refreshButton");
            WeatherConditionsList = AppSession.FindElementsByAccessibilityId("Label");
        }
    }
}
