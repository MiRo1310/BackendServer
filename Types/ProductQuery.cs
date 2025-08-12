using Microsoft.EntityFrameworkCore;
using Rezepte.Data;
using Rezepte.Models;

namespace Rezepte.Types;

[QueryType]

public static class ProductQuery
{
    public static IQueryable<Product> GetProducts(AppDbContext dbContext)
    {
        return dbContext.Products;
    }

    public static Product? GetProduct(AppDbContext dbContext, Guid id)
    {
        return dbContext.Products.FirstOrDefault(product => product.Id == id);
    }
}