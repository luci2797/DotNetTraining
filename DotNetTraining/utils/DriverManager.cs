using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.utils
{
    class DriverManager
    {
        public static IWebDriver driver = new ChromeDriver(Environment.CurrentDirectory);

        public static void InitializeDriver() {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Constants.HOMEPAGE_URL);
        }

        public static void CloseDriver() {
            driver.Close();
        }

    }
}
