using Amazon.DynamoDBv2;
using DotNetTraining.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.pages
{
    class BasePage
    {
        protected IWebDriver driver = DriverManager.driver;
        private bool is_logged_in = false;

        public IWebElement SearchBar {
            get {
                return driver.FindElement(By.Id("search_query_top"));
            }
        }

        public IList<IWebElement> CategoriesList {
            get {
                return driver.FindElements(By.CssSelector(".sf-menu>li"));
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

        public bool IsUserLoggedIn() {
            try
            {
                IWebElement element = LoginButton;
                //Console.WriteLine("login button:" + LoginButton.Text);
            }
            catch (NoSuchElementException) {
                is_logged_in = true;//if login button is not displayed the user is already logged in 
            }

            try
            {
                IWebElement element = LogoutButton;
                //Console.WriteLine("logout button: " + LogoutButton.Text);
            }
            catch (NoSuchElementException) {
                is_logged_in = false;//if logout button is not displayed the user is not logged in 
            }
            return is_logged_in;
        }

        public void ChooseCategoryByName(string name) {
            WebElementInteractions.ChooseByNameFromList(CategoriesList, name).Click();
        }

        public void SelectRandomElementInList(IList<IWebElement> list) {
            int randomIndex = Constants.RANDOM_NUMBER.Next(0, list.Count - 1);
            WebElementInteractions.ClickButton(list[randomIndex]);
        }

        public void SelectElementInList(IList<IWebElement> list, int index) {
            WebElementInteractions.ClickButton(list[index]);
        }


        public void MoveSliderHead(IWebElement sliderHead ,SliderHandle sliderHandle) {
            sliderHead.Click();
            if (sliderHandle == SliderHandle.LEFT)
            {
                for (int i = 0; i < Constants.RANDOM_NUMBER.Next(3, 10); i++)
                {
                    sliderHead.SendKeys(Keys.ArrowLeft);
                }
            }
            else {
                for (int i = 0; i < Constants.RANDOM_NUMBER.Next(3, 10); i++)
                {
                    sliderHead.SendKeys(Keys.ArrowRight);
                }
            }
        }

        public void DisplayStringList(List<string> list)
        {
            foreach (string element in list) {
                Console.Write(element + " ");
            }
        }

        public void SelectRandomOptionFromDropdown(IWebElement dropdownList) {
            var selectElement = new SelectElement(dropdownList);
            string[] options = dropdownList.Text.Split("\n");
            int randomIndex = Constants.RANDOM_NUMBER.Next(0, options.Length - 1);
            selectElement.SelectByIndex(randomIndex);
            Console.WriteLine("\noption selected:" + options[randomIndex]);
        }

        public void InputRandomAmount(IWebElement textField) {
            string randomAmount = Constants.RANDOM_NUMBER.Next(1, 10).ToString();
            WebElementInteractions.InputText(textField, randomAmount);
        }
    }
}
