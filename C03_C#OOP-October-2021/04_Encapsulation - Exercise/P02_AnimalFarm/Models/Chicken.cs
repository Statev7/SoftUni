namespace AnimalFarm.Models
{
    using System;

    public class Chicken
    {
        private const string NAME_ERROR_MESSAGE = "Name cannot be empty.";
        private const string AGE_ERROR_MESSAGE = "Age should be between 0 and 15.";

        private const int MIN_AGE = 0;
        private const int MAX_AGE = 15;

        private string name;
        private int age;

        internal Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(NAME_ERROR_MESSAGE);
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                bool isInvalid = value < MIN_AGE || value > MAX_AGE;
                if (isInvalid)
                {
                    throw new ArgumentException(AGE_ERROR_MESSAGE);
                }

                this.age = value;
            }
        }

        public double ProductPerDay
        {
            get
            {
                return this.CalculateProductPerDay();
            }
        }

        private double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }

        public override string ToString()
        {
            return $"Chicken {this.Name} (age {this.Age}) can produce {this.ProductPerDay} eggs per day.";
        }
    }
}
