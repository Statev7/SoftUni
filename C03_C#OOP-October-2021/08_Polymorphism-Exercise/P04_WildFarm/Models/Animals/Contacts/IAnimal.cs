namespace WildFarm.Models.Animals.Contracts
{
    using WildFarm.Models.Foods;

    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        string MakeSound();

        void Eat(Food food);
    }
}
