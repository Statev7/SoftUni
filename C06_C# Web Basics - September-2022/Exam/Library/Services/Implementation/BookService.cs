namespace Library.Services.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Library.Data;
    using Library.Data.Models;
    using Library.Models.Books;
    using Library.Services.Contracts;

    using Microsoft.EntityFrameworkCore;

    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
            => await this.dbContext.Books
            .Select(b => new BookViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                ImageUrl = b.ImageUrl,
                Rating = b.Rating,
                Description = b.Description,
                Category = b.Category.Name,
            })
            .ToListAsync();

        public async Task<UserBooksViewModel> GetAllByUserIdAsync(string userId) 
            => await this.dbContext.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserBooksViewModel
                {
                    Books = u.ApplicationUsersBooks
                        .Select(aub => new BookViewModel
                        {
                            Id = aub.Book.Id,
                            Title = aub.Book.Title,
                            Author = aub.Book.Author,
                            ImageUrl = aub.Book.ImageUrl,
                            Rating = aub.Book.Rating,
                            Description = aub.Book.Description,
                            Category = aub.Book.Category.Name,
                        })
                })
                .FirstOrDefaultAsync();

        public async Task CreateAsync(CreateBookInputModel model)
        {
            var book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                CategoryId = model.CategoryId,
            };

            await this.dbContext.Books.AddAsync(book);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
