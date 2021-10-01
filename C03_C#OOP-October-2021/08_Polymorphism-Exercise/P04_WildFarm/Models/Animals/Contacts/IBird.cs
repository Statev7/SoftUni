namespace WildFarm.Models.Animals.Contracts
{
    public interface IBird : IAnimal
    {
        double WingSize { get; }
    }
}
