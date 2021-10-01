namespace WildFarm.Models.Animals.Birds
{
    using WildFarm.Common.Constants;
    using WildFarm.Common.Exeptions;
    using WildFarm.Models.Foods;

    public class Owl : Bird
    {
        private const double WEIGHT_GAIN_PER_GRAM_VALUE = 0.25;
        private const string FOOD_THEY_CAN_EAT = "Meat";
        private const string SOUND_MESSAGE = "Hoot Hoot";

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string MakeSound()
        {
            return SOUND_MESSAGE;
        }

        public override void Eat(Food food)
        {
            var foodType = food.GetType().Name;
            if (foodType != FOOD_THEY_CAN_EAT)
            {
                var message = string.Format(GlobalConstatns.EAT_EXEPTION_MESSAGE, this.GetType().Name, foodType);

                throw new EatExeption(message);
            }

            this.Weight += food.Quantity * WEIGHT_GAIN_PER_GRAM_VALUE;
            this.FoodEaten += food.Quantity;
        }
    }
}
