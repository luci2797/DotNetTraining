using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.models
{
    class ColorOption
    {
        private string colorCode;
        private int numberOfProducts;

        public ColorOption(string color) {
            this.colorCode = color;
            numberOfProducts = 0;
        }

        public void  IncrementNumer() {
            numberOfProducts += 1;
        }

        public string ColorCode { get => colorCode; set => colorCode = value; }
        public int NumberOfProducts { get => numberOfProducts; set => numberOfProducts = value; }

        public override string ToString() {
            return "color option: color = " + colorCode + " number of products = " + numberOfProducts;
        }

    }
}
