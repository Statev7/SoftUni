namespace WildFarm.Models.Animals.Contracts
{
    public interface IMammal : IAnimal
    {
        string LivingRegion { get; }
    }
}
