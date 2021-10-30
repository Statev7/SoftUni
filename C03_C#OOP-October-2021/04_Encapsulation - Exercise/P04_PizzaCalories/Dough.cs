namespace PizzaCalories
{
    using System;

    public class Dough
    {
        private const int WEIGHT_MIN_VALUE = 1;
        private const int WEIGHT_MAX_VALUE = 200;
        private const string DOUGH_ERROR_MESSAGE = "Invalid type of dough.";
        private const string WEIGHT_ERROR_MESSAGE = "Dough weight should be in the range [1..200].";

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                bool isInvalid = this.CheckTypeIsInvalid(value);
                if (isInvalid)
                {
                    throw new ArgumentException(DOUGH_ERROR_MESSAGE);
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                bool isInvalid = this.CheckTypeIsInvalid(value);
                if (isInvalid)
                {
                    throw new ArgumentException(DOUGH_ERROR_MESSAGE);
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                bool isInvalid = this.CheckWeightIsInvalid(value);
                if (isInvalid)
                {
                    throw new ArgumentException(WEIGHT_ERROR_MESSAGE);
                }

                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double totalCalories = 0;

            double typeGrams = Modifiers(this.FlourType);
            double techniqueGrams = Modifiers(this.BakingTechnique);

            totalCalories = (2 * this.Weight) * typeGrams * techniqueGrams;

            return totalCalories;
        }

        private double Modifiers(string type)
        {
            double grams = 0;
            type = type.ToLower();

            switch (type)
            {
                case "white": grams = 1.5; break;
                case "wholegrain": grams = 1.0; break;
                case "crispy": grams = 0.9; break;
                case "chewy": grams = 1.1; break;
                case "homemade": grams = 1.0; break;
            }

            return grams;
        }

        private bool CheckTypeIsInvalid(string type)
        {
            type = type.ToLower();
            bool isInvalid = type != "white" && 
                             type != "wholegrain" &&
                             type != "crispy" &&
                             type != "chewy" &&
                             type != "homemade";

            return isInvalid;
        }

        private bool CheckWeightIsInvalid(double weight)
        {
            bool isInvalid = weight < WEIGHT_MIN_VALUE || weight > WEIGHT_MAX_VALUE;

            return isInvalid;
        }
    }
}
