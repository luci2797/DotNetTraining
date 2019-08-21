using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.pages
{
    class PersonalInfoPage:BasePage
    {
        public IWebElement MyEmailField {
            get {
                return driver.FindElement(By.Id("email"));
            }
        }

        public string GetEmail() {
            return MyEmailField.GetAttribute("value");
        }
    }
}
