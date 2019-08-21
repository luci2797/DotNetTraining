using DotNetTraining.steps;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.tests
{
    class LoginTests:BaseTest
    {
        BaseSteps baseSteps = new BaseSteps();
        LoginSteps loginSteps = new LoginSteps();
        AccountSteps accountSteps = new AccountSteps();
        PersonalInfoSteps personalInfoSteps = new PersonalInfoSteps();


        [Test]
        public void LoginTest() {
            baseSteps.PerformLogout();
            baseSteps.NavigateToLoginPage();
            loginSteps.PerformLogin();
            loginSteps.CheckIfLoggedIn();
            accountSteps.GoToPersonalInfo();
            personalInfoSteps.CheckEmail();
        }

    }
}
