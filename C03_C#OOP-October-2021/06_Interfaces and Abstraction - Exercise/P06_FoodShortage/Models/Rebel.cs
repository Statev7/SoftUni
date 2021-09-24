namespace FoodShortage.Models
{
    class Rebel : Person
    {
        private const int FOOD_INCREAS_VALUE = 5;

        public Rebel(string name, int age, string group) 
            : base(name, age)
        {
            this.Group = group;
        }

        public string Group { get; private set; }

        public override void BuyFood()
        {
            this.Food += FOOD_INCREAS_VALUE;
        }
    }
}
