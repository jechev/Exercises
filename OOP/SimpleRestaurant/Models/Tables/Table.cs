using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table:ITable
    {
        private List<Food> foodOrders;
        private List<Drink> drinkOrders;
        private int capacity;
        private int numberOfPeople;
        private decimal price;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<Food>();
            this.drinkOrders = new List<Drink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        public int TableNumber { get; set; }

        public decimal PricePerPerson { get; set; }

        public bool IsReserved { get; set; }

        public int Capacity
        {
            get { return this.capacity; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                else
                {
                    this.capacity = value;
                }
            }
        }

        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                else
                {
                    this.numberOfPeople = value;
                }
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                this.price = this.PricePerPerson * this.numberOfPeople;
            }    
        }
    }
}
