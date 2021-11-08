namespace P01_Logger.Models.Contracts
{
    public interface IFile
    {
        string Path { get; }

        int Size { get; }

        string Write(ILayout Layout, IError error);
    }
}
