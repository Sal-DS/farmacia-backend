using System.Runtime.CompilerServices;
using Farmacia.api.Data;
using Farmacia.api.Models;
using Microsoft.EntityFrameworkCore;
public class CategoryRepository : ICategoryRepository
{   
    private FarmaciaDbContext _dbcontext;
    
    public CategoryRepository(FarmaciaDbContext db)
    {
        _dbcontext = db;
    }
    public async Task<bool> ExistAsync(int id)
    {
        return await _dbcontext.Categories.AnyAsync(c => c.Id == id);
    }
}