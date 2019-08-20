using DotNetTraining.steps;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.tests
{
    class SearchTests:BaseTest
    {
        BaseSteps baseSteps = new BaseSteps();
        SearchResultsSteps searchResultsSteps = new SearchResultsSteps();

        [Test]
        public void SearchResultsUiTest() {
            baseSteps.SearchProduct();
            searchResultsSteps.CheckSearchTermDisplayed();
            searchResultsSteps.CheckNoOfResultsDisplayed();
            searchResultsSteps.CheckSearchUrl();

        }

    }
}
