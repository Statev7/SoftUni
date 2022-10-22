namespace Library.Services.Contracts
{
    using Library.Models.Categories;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryIdNameViewModel>> GetAllAsync();

        Task<bool> IsExistAsync(int id);
    }
}
