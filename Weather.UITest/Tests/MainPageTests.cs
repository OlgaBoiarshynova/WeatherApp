using NUnit.Framework;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.UITest.PageObjects;
using Weather.UITest.Tests;

namespace Weather.UITest
{
    [TestFixture]
    public class MainPageTests : BaseTest
    {


        [Test]
        [Category("MainPageTests")]
        public void TestMethod()
        {
            MainPage mainPage = new MainPage(session);
            

        }
    }
}
