using DotNetTraining.pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.steps
{
    class AccountSteps
    {
        AccountPage accountPage = new AccountPage();

        public void GoToPersonalInfo() {
            accountPage.ChooseOptionByName("information");
        }
    }
}
