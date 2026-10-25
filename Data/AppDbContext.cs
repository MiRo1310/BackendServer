using BackendServer.Models.Entities.IoBroker;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; } // Virtuelle Tabelle für Rezepte

    public DbSet<Unit> Units { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductUnit> ProductUnits { get; set; }

    public DbSet<RecipeProductHeader> RecipeProductHeaders { get; set; }

    public DbSet<RecipeProduct> RecipeProducts { get; set; }

    public DbSet<ProductCategory> ProductCategories { get; set; }

    public DbSet<RecipeDescription> RecipeDescriptions { get; set; }
    
    public DbSet<RecipeCategory> RecipeCategories { get; set; }

    public DbSet<FrontendLog> FrontendLog { get; set; }
}