using Farmacia.api.Models;

public interface ICategoryRepository
{
    Task<bool> ExistAsync(int id);
    Task<IEnumerable<Category>> GetAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<Category> AddAsync(Category category);
    Task<bool> UpdateAsync(Category category);
    Task<bool> DeleteAsync(int id);
}
