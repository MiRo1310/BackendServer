using Microsoft.EntityFrameworkCore;
using Rezepte.Models;

namespace Rezepte.Data;
public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Recipe> Recipes { get; set; } // Virtuelle Tabelle für Rezepte
    
    public DbSet<Unit> Units { get; set; }
    
    public DbSet<Product> Products { get; set; } 
    
    public DbSet<ProductUnit> ProductUnits { get; set; }
    
    public DbSet<RecipeHeaderProduct> ProductHeaders { get; set; }
    
    public DbSet<RecipeProduct> RecipeProducts { get; set; }
    
    public DbSet<ProductCategory> ProductCategories { get; set; }
    
    public DbSet<RecipeTextArea> RecipeTextAreas { get; set; }
    
    public DbSet<RecipeHeader> RecipeHeaders { get; set; }
    
    
    public DbSet<Hund> Hund { get; set; }
    
    
    
}