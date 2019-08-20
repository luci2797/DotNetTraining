using DotNetTraining.utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.pages
{
    class SearchResultsPage:BasePage
    {
        private IWebElement DisplayedSearchTerm {
            get {
                return driver.FindElement(By.CssSelector(".lighter"));
            }
        }

        public IList<IWebElement> ProductsFoundList {
            get {
                return driver.FindElements(By.CssSelector(".ajax_block_product"));
            }
        }

        private IWebElement NoOfProductsFoundText {
            get {
                return driver.FindElement(By.CssSelector(".heading-counter"));
            }
        }

        public bool IsTermDisplayedCorrectly() {
            if (DisplayedSearchTerm.Text.ToLower().Contains(Constants.SEARCH_TERM.ToLower()))
            {
                return true;
            }
            else {
                return false;
            }
        }

        public bool WereProductsFound() {
            if (ProductsFoundList.Count > 0)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public bool IsNoFoundDisplayedCorrectly() {
            string numberDisplayed = NoOfProductsFoundText.Text;
            int numberFound = ProductsFoundList.Count;
            if (numberDisplayed.Contains(numberFound.ToString()))
            {
                return true;
            }
            else {
                return false;
            }
        }

        public bool IsUrlCorrect() {
            if (GetCurrentUrl().ToLower().Contains(Constants.SEARCH_TERM.ToLower()))
            {
                return true;
            }
            else {
                return false;
            }
        }


    }
}
