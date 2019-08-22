using DotNetTraining.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.utils
{
    class Constants
    {
        public static string HOMEPAGE_URL = "http://automationpractice.com/index.php";
        public static string MY_ACCOUNT_URL = "http://automationpractice.com/index.php?controller=my-account";
        public static string SEARCH_TERM = "shirt";
        public static string VALID_EMAIL_ADDRESS = "aabc@gmail.com";
        public static string VALID_PASSWORD = "password";
        public static string PRODUCT_SESSION_VAR = "product chosen from list";
        public static Random RANDOM_NUMBER = new Random();
        public static Product ChosenProduct;
    }
}
