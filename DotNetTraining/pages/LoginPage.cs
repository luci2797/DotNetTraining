using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.pages
{
    class LoginPage : BasePage
    {
        public IWebElement LoginEmailField {
            get {
                return driver.FindElement(By.Id("email"));
            }
        }

        public IWebElement LoginPasswordField {
            get {
                return driver.FindElement(By.Id("passwd"));
            }
        }

        public IWebElement LoginFormButton {
            get {
                return driver.FindElement(By.Id("SubmitLogin"));
            }
        }
    }
}
