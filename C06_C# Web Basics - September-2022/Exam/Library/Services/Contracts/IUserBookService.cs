namespace Library.Services.Contracts
{
    public interface IUserBookService
    {
        Task AddBookAsync(int bookId, string userId);

        Task RemoveBookAsync(int bookId, string userId);
    }
}
