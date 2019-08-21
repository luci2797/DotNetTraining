using DotNetTraining.pages;
using DotNetTraining.utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.steps
{
    class PersonalInfoSteps
    {
        PersonalInfoPage personalInfoPage = new PersonalInfoPage();

        public void CheckEmail() {
            Assert.IsTrue(personalInfoPage.GetEmail().Equals(Constants.VALID_EMAIL_ADDRESS));
        }
    }
}
