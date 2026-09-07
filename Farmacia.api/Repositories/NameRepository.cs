using System.Runtime.CompilerServices;
using Farmacia.api.Data;
using Farmacia.api.Models;
using Microsoft.EntityFrameworkCore;

public class NameRepository : INameRepository
{
    private FarmaciaDbContext _dbcontext;
    public NameRepository(FarmaciaDbContext context)
    {
        _dbcontext = context;
    }
    public async Task<bool> ExistName(string name, string manufacturer)
    {
        return await _dbcontext.Products.AnyAsync(n => n.Name == name && n.Manufacturer == manufacturer);
    }
}