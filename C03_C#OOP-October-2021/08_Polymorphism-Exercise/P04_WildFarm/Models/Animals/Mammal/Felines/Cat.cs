namespace WildFarm.Models.Animals.Mammal.Felines
{
    using WildFarm.Common.Constants;
    using WildFarm.Common.Enums;
    using WildFarm.Common.Exeptions;
    using WildFarm.Models.Foods;

    public class Cat : Feline
    {
        private const double WEIGHT_GAIN_PER_GRAM_VALUE = 0.30;
        private const string SOUND_MESSAGE = "Meow";

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string MakeSound()
        {
            return SOUND_MESSAGE;
        }

        public override void Eat(Food food)
        {
            var foodType = food.GetType().Name;

            bool isInvalid = foodType != CatFood.Meat.ToString() && 
                             foodType != CatFood.Vegetable.ToString();
            if (isInvalid)
            {
                var message = string.Format(GlobalConstatns.EAT_EXEPTION_MESSAGE, this.GetType().Name, foodType);

                throw new EatExeption(message);
            }

            this.Weight += food.Quantity * WEIGHT_GAIN_PER_GRAM_VALUE;
            this.FoodEaten += food.Quantity;
        }
    }
}
