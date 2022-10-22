namespace Library.Services.Contracts
{
    using Library.Models.Books;

    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetAllAsync();

        Task<UserBooksViewModel> GetAllByUserIdAsync(string userId);

        Task CreateAsync(CreateBookInputModel model);
    }
}
