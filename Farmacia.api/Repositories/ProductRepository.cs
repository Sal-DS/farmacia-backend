using Farmacia.api.Data;
using Farmacia.api.Models;
using Microsoft.EntityFrameworkCore;
public class ProductRepository : IProductRepository
{
    private readonly FarmaciaDbContext _context;

    public ProductRepository(FarmaciaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products
            .Include(p => p.Category)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product is null)
            return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        
        return true;
    }
}