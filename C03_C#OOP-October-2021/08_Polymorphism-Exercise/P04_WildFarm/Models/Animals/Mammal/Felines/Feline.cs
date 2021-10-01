namespace WildFarm.Models.Animals.Mammal.Felines
{
    using WildFarm.Models.Animals.Contracts;

    public abstract class Feline : Mammal, IFeline
    {
        protected Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            var result = $"{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";

            return base.ToString() + result;
        }
    }
}
