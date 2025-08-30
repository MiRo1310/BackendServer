using BackendServer.Data;
using BackendServer.Models.Product;
using Microsoft.EntityFrameworkCore;
using BackendServer.Models;

namespace BackendServer.Types;

[QueryType]

public static class ProductQuery
{
    public static IQueryable<Product> GetProducts(AppDbContext dbContext)
    {
        return dbContext.Products
        .Include(product => product.ProductUnits )
        .Include(product =>product.RecipeProducts );
    }

    public static Product? GetProduct(AppDbContext dbContext, Guid id)
    {
        return dbContext.Products
            .Include(product => product.ProductUnits )
            .Include(product =>product.RecipeProducts )
            .FirstOrDefault(product => product.Id == id);
    }
}