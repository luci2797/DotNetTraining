using System;
using System.Collections.Generic;
using System.Text;
using DotNetTraining.utils;
using NUnit.Framework;

namespace DotNetTraining.tests
{
    class BaseTest
    {
        [SetUp]
        public void Initialize()
        {
            DriverManager.InitializeDriver();
        }

        [TearDown]
        public void Cleanup() {
            DriverManager.CloseDriver();
        }
    }
}
