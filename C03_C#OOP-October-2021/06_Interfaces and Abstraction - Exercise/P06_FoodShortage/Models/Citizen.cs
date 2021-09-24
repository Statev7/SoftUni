namespace FoodShortage.Models
{
    public class Citizen : Person
    {
        private const int FOOD_INCREAS_VALUE = 10;

        public Citizen(string name, int age, string id, string birthDate) 
            : base(name, age)
        {
            this.Id = id;
            this.BirthDate = birthDate;
        }

        public string Id { get; private set; }

        public string BirthDate { get; private set; }

        public override void BuyFood()
        {
            this.Food += FOOD_INCREAS_VALUE;
        }
    }
}
