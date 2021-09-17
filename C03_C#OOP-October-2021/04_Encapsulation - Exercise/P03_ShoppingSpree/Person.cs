namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private const string NAME_ERROR_MESSAGE = "Name cannot be empty";
        private const string MONEY_ERROR_MESSAGE = "Money cannot be negative";

        private string name;
        private double money;
        private readonly List<Product> bag;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(NAME_ERROR_MESSAGE);
                }

                this.name = value;
            }
        }

        public double Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(MONEY_ERROR_MESSAGE);
                }

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag => this.bag.AsReadOnly();

        public string BuyProduct(Product product)
        {
            bool canBuyProduct = this.Money >= product.Cost;
            if (canBuyProduct)
            {
                this.Money -= product.Cost;
                this.bag.Add(product);
                return $"{this.Name} bought {product.Name}";
            }

            return $"{this.Name} can't afford {product.Name}";
        }
    }
}
