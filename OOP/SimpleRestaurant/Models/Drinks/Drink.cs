using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public abstract class Drink:IDrink
    {
        private string name;
        private int servingSize;
        private decimal price;
        private string brand;

        public Drink(string name, int servingSize, decimal price, string brand)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
            this.Brand = brand;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int ServingSize
        {
            get { return this.servingSize; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Serving size cannot be less or equal to zero!");
                }
                else
                {
                    this.servingSize = value;
                }
            }
        }

        public decimal Price
        {
            get {return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public string Brand
        {
            get { return this.brand; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand cannot be null or white space!");
                }
                else
                {
                    this.brand = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.name} {this.brand} - {this.servingSize}ml - {this.price:C2}";
        }
    }
}
