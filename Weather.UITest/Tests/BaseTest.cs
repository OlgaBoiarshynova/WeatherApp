using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.UITest.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string AppUIBasicAppId = "bb09e398-5921-4843-a0f0-c5b451ec97b8_pkhbb7851wqvw!App";
        protected static WindowsDriver<WindowsElement> session = null;
        protected Process process;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + "\"C:\\Program Files (x86)\\Windows Application Driver\\WinAppDriver.exe\"");
            process = Process.Start(processInfo);
        }

        [SetUp]
        public void Setup()
        {                    
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", AppUIBasicAppId);
            session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TearDown() {
            session.Quit();
           
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            process.CloseMainWindow();
        }
    }
}
