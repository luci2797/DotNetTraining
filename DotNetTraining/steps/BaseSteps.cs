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
    }
}
