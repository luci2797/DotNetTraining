using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.models
{
    class Product
    {
        private string name;
        private float price;

        public Product(string prodName, float prodPrice) {
            this.name = prodName;
            this.price = prodPrice;
        }

        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }

        public override string ToString()
        {
            return "product: " + "name = " + this.name + " price = " + this.price;
        }
    }
}
