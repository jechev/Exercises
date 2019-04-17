using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public abstract class Food:IFood
    {
        private string name;
        private int servingSize;
        private decimal price;


        public Food(string name, int servingSize, decimal price)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
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
            get { return this.price; }
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

        public override string ToString()
        {
            return $"{this.name}: {this.servingSize}g - {this.price:C2}";
        }
    }
}
