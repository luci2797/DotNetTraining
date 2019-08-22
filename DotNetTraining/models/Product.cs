using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.models
{
    class Product
    {
        private string name;
        private float price;
        private List<string> colors;

        public Product(string prodName, float prodPrice) {
            this.name = prodName;
            this.price = prodPrice;
            this.Colors = new List<string>();
        }

        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
        public List<string> Colors { get => colors; set => colors = value; }

        public void AddColor(string color) {
            Colors.Add(color);
        }

        public void RemoveColor(string color) {
            Colors.Remove(color);
        }

        public string GetColorByIndex(int index) {
            return Colors[index];
        }

        private string DisplayColors() {
            string colorString = " colors available: ";
            foreach (string color in this.Colors) {
                colorString += color + " ";
            }
            return colorString;
        }

        public override string ToString()
        {
            return "product: " + "name = " + this.name + " price = " + this.price + this.DisplayColors();
        }
    }
}
