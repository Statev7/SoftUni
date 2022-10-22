namespace Library.Services.Implementation
{
    using System.Threading.Tasks;

    using Library.Data;
    using Library.Data.Models;
    using Library.Services.Contracts;

    using Microsoft.EntityFrameworkCore;

    public class UserBookService : IUserBookService
    {
        private readonly LibraryDbContext dbContext;

        public UserBookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddBookAsync(int bookId, string userId)
        {
            try
            {
                await IsBookAndUserExist(bookId, userId);

                bool IsExistReletionAlready = await this.IsExistReletionAlready(bookId, userId);
                if (IsExistReletionAlready)
                {
                    throw new ArgumentException("Book is already in collection!");
                }

                var userBook = new ApplicationUserBook()
                {
                    BookId = bookId,
                    ApplicationUserId = userId,
                };

                await this.dbContext.ApplicationUserBooks.AddAsync(userBook);
                await this.dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemoveBookAsync(int bookId, string userId)
        {
            try
            {
                await IsBookAndUserExist(bookId, userId);

                bool IsExistReletionAlready = await this.IsExistReletionAlready(bookId, userId);
                if (!IsExistReletionAlready)
                {
                    throw new ArgumentException("This book is not in your collection!");
                }

                var userBook = new ApplicationUserBook()
                {
                    BookId = bookId,
                    ApplicationUserId = userId,
                };

                this.dbContext.ApplicationUserBooks.Remove(userBook);
                await this.dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task IsBookAndUserExist(int bookId, string userId)
        {
            var book = await this.dbContext.Books.FindAsync(bookId);
            if (book == null)
            {
                throw new ArgumentException("Book does not exist!");
            }

            var user = await this.dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("User does not exist!");
            }
        }

        private async Task<bool> IsExistReletionAlready(int bookId, string userId)
            => await this.dbContext
                .ApplicationUserBooks
                .AnyAsync(aub => aub.BookId == bookId && aub.ApplicationUserId == userId);
    }
}
