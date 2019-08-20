using DotNetTraining.utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.pages
{
    class BasePage
    {
        protected IWebDriver driver = DriverManager.driver;

        public IWebElement SearchBar {
            get {
                return driver.FindElement(By.Id("search_query_top"));
            }
        }

        public IWebElement MainLogo {
            get {
                return driver.FindElement(By.Id("header_logo"));
            }
        }

        public IWebElement ShoppingCartButton {
            get {
                return driver.FindElement(By.CssSelector(".shopping_cart >a"));
            }
        }

        public IList<IWebElement> SocialMediaLinks {
            get {
                return driver.FindElements(By.CssSelector("#social_block li"));
            }
        }

        public IWebElement LoginButton {
            get {
                return driver.FindElement(By.CssSelector(".login"));
            }
        }

        public IWebElement LogoutButton {
            get {
                return driver.FindElement(By.CssSelector(".logout"));
            }
        }

        public string GetCurrentUrl() {
            return driver.Url;
        }
    }
}
