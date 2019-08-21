using DotNetTraining.utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.pages
{
    class AccountPage:BasePage
    {
        public IList<IWebElement> MyAccountLinks {
            get {
                return driver.FindElements(By.CssSelector(".myaccount-link-list li"));
            }
        }

        public void ChooseOptionByName(string name) {
            IWebElement elementFound = WebElementInteractions.ChooseByNameFromList(MyAccountLinks, name);
            if (elementFound == null)
            {
                Console.WriteLine("no element with the name specified was found");
            }
            else {
                WebElementInteractions.ClickButton(elementFound);
            }
        }

    }
}
