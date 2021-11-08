namespace P01_Logger.Models.Contracts
{
    using P01_Logger.Models.Enumerations;

    public interface IError
    {
        string DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}
