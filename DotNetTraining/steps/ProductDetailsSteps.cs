using DotNetTraining.pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.steps
{
    class ProductDetailsSteps
    {
        ProductDetailsPage productDetailsPage = new ProductDetailsPage();

        public void CheckIfProductDetailsMatch() {
            Assert.IsTrue(productDetailsPage.IsProductTheSame());
        }
    }
}
