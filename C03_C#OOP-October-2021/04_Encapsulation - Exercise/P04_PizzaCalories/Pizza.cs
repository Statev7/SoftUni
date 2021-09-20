namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Pizza
    {
        private const int NAME_MAX_LENGHT_VALUE = 15;
        private const int TOPPINGS_MAX_COUNT_VALUE = 10;

        private const string NAME_ERROR_MESSAGE = "Pizza name should be between 1 and 15 symbols.";
        private const string TOPPING_ERROR_MESSAGE = "Number of toppings should be in range [0..10].";

        private string name;
        private Dough dough;
        private readonly List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                bool isInvalid = this.CheckNameIsInvalid(value);
                if (isInvalid)
                {
                    throw new ArgumentException(NAME_ERROR_MESSAGE);
                }

                this.name = value;
            }
        }

        public Dough Dough { get; }

        public double NumbersOfTopings => this.toppings.Count;

        public double TotalCalories { get; private set; }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count >= TOPPINGS_MAX_COUNT_VALUE)
            {
                throw new ArgumentException(TOPPING_ERROR_MESSAGE);
            }

            this.toppings.Add(topping);
        }

        private double CalculateTotalCalories()
        {
            double toppingsTotalCalories = 0;

            foreach (var topping in this.toppings)
            {
                toppingsTotalCalories += topping.CalculateCalories();
            }

            double totalCalories = this.Dough.CalculateCalories() + toppingsTotalCalories;
            return totalCalories;
        }

        private bool CheckNameIsInvalid(string name)
        {
            bool isInvalid = string.IsNullOrEmpty(name) || name.Length > NAME_MAX_LENGHT_VALUE;

            return isInvalid;
        }

        public override string ToString()
        {
            this.TotalCalories = this.CalculateTotalCalories();

            return $"{this.Name} - {TotalCalories:F2} Calories.";
        }
    }
}
