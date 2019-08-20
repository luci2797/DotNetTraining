using DotNetTraining.pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.steps
{
    class SearchResultsSteps
    {
        SearchResultsPage searchResultsPage = new SearchResultsPage();

        public void CheckSearchTermDisplayed() {
            Assert.IsTrue(searchResultsPage.IsTermDisplayedCorrectly());
        }

        public void CheckNoOfResultsDisplayed() {
            Assert.IsTrue(searchResultsPage.IsNoFoundDisplayedCorrectly());
        }

        public void CheckSearchUrl() {
            Assert.IsTrue(searchResultsPage.IsUrlCorrect());
        }
    }
}
