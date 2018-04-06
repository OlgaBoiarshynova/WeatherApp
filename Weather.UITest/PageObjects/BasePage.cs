using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.UITest.PageObjects
{
    public abstract class BasePage
    {
        protected WindowsDriver<WindowsElement> AppSession { get; set; }
        protected WindowsElement ContentElement { get; set; }
        public abstract bool IsPageOpen { get; }


        protected BasePage(WindowsDriver<WindowsElement> appSession)
        {
            AppSession = appSession;
            InitializeElements();
        }       

        protected virtual void InitializeElements()
        {
            ContentElement = AppSession.FindElementByAccessibilityId("contentElement");
        }
    }
}
