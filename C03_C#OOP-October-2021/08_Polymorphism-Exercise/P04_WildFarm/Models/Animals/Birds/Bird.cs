namespace WildFarm.Models.Animals.Birds
{
    using WildFarm.Models.Animals.Contracts;

    public abstract class Bird : Animal, IBird
    {
        protected Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            var result = $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";

            return base.ToString() + result;
        }
    }
}
