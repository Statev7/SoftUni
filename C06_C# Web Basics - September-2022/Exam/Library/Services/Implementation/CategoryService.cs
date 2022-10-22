namespace Library.Services.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Library.Data;
    using Library.Models.Categories;
    using Library.Services.Contracts;

    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {
        private readonly LibraryDbContext dbContext;

        public CategoryService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryIdNameViewModel>> GetAllAsync()
            => await this.dbContext.Categories
               .Select(c => new CategoryIdNameViewModel
               {
                   Id = c.Id,
                   Name = c.Name,
               })
               .ToListAsync();

        public Task<bool> IsExistAsync(int id)
            => this.dbContext.Categories.AnyAsync(x => x.Id == id);
    }
}
