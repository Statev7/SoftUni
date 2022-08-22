namespace P01_Chronometer.Factories.Contracts
{
    public interface IFactory<TEntity>
        where TEntity : class
    {
        TEntity Create(params string[] args);
    }
}
