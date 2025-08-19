using Bulky.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new List<Category>()
        {
            new() {Id = 1, Name = "Action", DisplayOrder = 1},
            new() {Id = 2, Name = "SciFi", DisplayOrder = 2},
            new() {Id = 3, Name = "History", DisplayOrder = 3},
            new() {Id = 4, Name = "Romance", DisplayOrder = 4},
            new() {Id = 5, Name = "Scholar", DisplayOrder = 5},
        });

        modelBuilder.Entity<Product>().HasData(new List<Product>()
        {

        });
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}