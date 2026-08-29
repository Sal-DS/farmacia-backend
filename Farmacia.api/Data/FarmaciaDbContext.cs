using Farmacia.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Farmacia.api.Data;

public class FarmaciaDbContext : DbContext
{
    //
    public FarmaciaDbContext(DbContextOptions<FarmaciaDbContext> options) : base(options)
    {
        
    }
    //Transformei as classes em tabelas:
    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }
}