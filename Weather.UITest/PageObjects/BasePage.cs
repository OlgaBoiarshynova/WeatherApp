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
        protected BasePage(WindowsDriver<WindowsElement> appSession)
        {
            AppSession = appSession;
            InitializeElements();
        }

        protected WindowsDriver<WindowsElement> AppSession { get; set; }

        protected abstract void InitializeElements();
    }
}
