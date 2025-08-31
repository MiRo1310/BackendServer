using BackendServer.Models;
using BackendServer.Models.Product;
using BackendServer.Models.ProductCategory;
using BackendServer.Models.ProductUnit;
using BackendServer.Models.Recipe;
using BackendServer.Models.RecipeDescription;
using BackendServer.Models.RecipeProduct;
using BackendServer.Models.RecipeProductHeader;
using BackendServer.Models.Unit;
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

    public DbSet<RecipeProductHeader> ProductHeaders { get; set; }

    public DbSet<RecipeProduct> RecipeProducts { get; set; }

    public DbSet<ProductCategory> ProductCategories { get; set; }

    public DbSet<RecipeDescription> RecipeDescriptions { get; set; }
}