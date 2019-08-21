using DotNetTraining.pages;
using DotNetTraining.utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.steps
{
    class LoginSteps
    {
        LoginPage loginPage = new LoginPage();
        public void InputEmailAddress() {
            WebElementInteractions.InputText(loginPage.LoginEmailField, Constants.VALID_EMAIL_ADDRESS);
        }

        public void InputPassword() {
            WebElementInteractions.InputText(loginPage.LoginPasswordField, Constants.VALID_PASSWORD);
        }

        public void SubmitLoginForm() {
            WebElementInteractions.ClickButton(loginPage.LoginFormButton);
        }

        public void PerformLogin() {
            this.InputEmailAddress();
            this.InputPassword();
            this.SubmitLoginForm();
        }

        public void CheckIfLoggedIn() {
            Assert.IsTrue(loginPage.GetCurrentUrl().Equals(Constants.MY_ACCOUNT_URL));
        }
    }
}
