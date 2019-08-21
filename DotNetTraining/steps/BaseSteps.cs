using DotNetTraining.pages;
using DotNetTraining.utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.steps
{
    class BaseSteps
    {
        BasePage basePage = new BasePage();

        public void SearchProduct() {
            WebElementInteractions.InputText(basePage.SearchBar, Constants.SEARCH_TERM);
            basePage.SearchBar.Submit();
        }

        public bool CheckIfLoggedIn() {
            Console.WriteLine("is the user logged in : " + basePage.IsUserLoggedIn());
            return basePage.IsUserLoggedIn();
        }

        public void PerformLogout() {
            if (basePage.IsUserLoggedIn()) {
                WebElementInteractions.ClickButton(basePage.LogoutButton);
            }
        }

        public void NavigateToLoginPage() {
            if (!this.CheckIfLoggedIn())
            {
                WebElementInteractions.ClickButton(basePage.LoginButton);
            }
            else {
                Console.WriteLine("user is already logged in");
            }
        }
    }
}
