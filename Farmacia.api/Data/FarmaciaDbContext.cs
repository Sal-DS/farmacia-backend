using Farmacia.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Farmacia.api.Data;

public class FarmaciaDbContext : DbContext
{
    public FarmaciaDbContext(DbContextOptions<FarmaciaDbContext> options) : base(options)
    {
        
    }
    //Transformei as classes em tabelas:
    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    //Define os relacionamentos da entidade Product
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
        .HasOne(p => p.Category)
        .WithMany(p => p.Products)
        .HasForeignKey(p => p.CategoryId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}