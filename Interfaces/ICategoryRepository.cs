using ArtMart.Models;

namespace ArtMart.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> AddAsync(Category category);
        Task<bool> DeleteAsync(int id);
    }
}
