using Farmacia.api.Data;
using Farmacia.api.Models;
using Microsoft.EntityFrameworkCore;
public class CategoryRepository : ICategoryRepository
{   
    private readonly FarmaciaDbContext _dbcontext;
    
    public CategoryRepository(FarmaciaDbContext db)
    {
        _dbcontext = db;
    }
    public async Task<bool> ExistAsync(int id)
    {
        return await _dbcontext.Categories.AnyAsync(c => c.Id == id);
    }
    public async Task<IEnumerable<Category>> GetAsync()
    {
        return await _dbcontext.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _dbcontext.Categories.FindAsync(id);
    }

    public async Task<Category> AddAsync(Category category)
    {
        _dbcontext.Categories.Add(category);
        await _dbcontext.SaveChangesAsync();
        return category;
    }

    public async Task<bool> UpdateAsync(Category category)
    {
        await _dbcontext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _dbcontext.Categories.FindAsync(id);
        if (category is null)
        {
            return false;
        }

        _dbcontext.Categories.Remove(category);
        await _dbcontext.SaveChangesAsync();
        return true;
    }
}
