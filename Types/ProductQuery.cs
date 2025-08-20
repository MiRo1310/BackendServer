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
        .Include(product => product.ProductUnits );
    }

    public static Product? GetProduct(AppDbContext dbContext, Guid id)
    {
        return dbContext.Products
            .Include(product => product.ProductUnits )
            .FirstOrDefault(product => product.Id == id);
    }
}