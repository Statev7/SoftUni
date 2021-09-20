namespace ShoppingSpree
{
    using System;

    public class Product
    {
        private const string NAME_ERROR_MESSAGE = "Name cannot be empty";
        private const string MONEY_ERROR_MESSAGE = "Money cannot be negative";

        private string name;
        private double cost;

        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
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

        public double Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(MONEY_ERROR_MESSAGE);
                }

                this.cost = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
