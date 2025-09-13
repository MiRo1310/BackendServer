using BackendServer.Data;
using BackendServer.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Types;

[QueryType]

public static class ProductQuery
{
    public static IQueryable<Product> GetProducts(AppDbContext dbContext)
    {
        return dbContext.Products
        .Include(p => p.ProductUnits )
        .Include(p =>p.RecipeProducts )
        .Include(p=> p.ProductCategory);
    }

    public static Product? GetProduct(AppDbContext dbContext, Guid id)
    {
        return dbContext.Products
            .Include(product => product.ProductUnits )
            .Include(product =>product.RecipeProducts )
            .Include(p => p.ProductCategory)
            .FirstOrDefault(p => p.Id == id);
    }
}