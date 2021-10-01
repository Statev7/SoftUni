namespace WildFarm.Models.Animals.Birds
{
    using WildFarm.Common.Constants;
    using WildFarm.Common.Exeptions;
    using WildFarm.Models.Foods;

    public class Hen : Bird
    {
        private const double WEIGHT_GAIN_PER_GRAM_VALUE = 0.35;
        private const string SOUND_MESSAGE = "Cluck";

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string MakeSound()
        {
            return SOUND_MESSAGE;
        }

        public override void Eat(Food food)
        {
            this.Weight += food.Quantity * WEIGHT_GAIN_PER_GRAM_VALUE;
            this.FoodEaten += food.Quantity;
        }
    }
}
