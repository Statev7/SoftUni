namespace P01_Logger.Models.Contracts
{
    using P01_Logger.Models.Enumerations;

    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        int MessagesAppended { get; }

        void Apeend(IError error);
    }
}
