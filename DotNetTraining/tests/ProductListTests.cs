using DotNetTraining.steps;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.tests
{
    class ProductListTests:BaseTest
    {
        ProductListSteps productListSteps = new ProductListSteps();
        BaseSteps baseSteps = new BaseSteps();

        [Test]
        public void ColorOptionsTest() {
            baseSteps.NavigateToCategory("dresses");
            productListSteps.DisplayColorOptions();
            productListSteps.DisplayCountedColors();
            productListSteps.CheckColors();
        }
    }
}
