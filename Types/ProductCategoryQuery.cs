using BackendServer.Data;
using BackendServer.Models.ProductCategory;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Types;

[QueryType]

public static class ProductCategoryQuery
{
    public static IQueryable<ProductCategory> GetProductCategories(AppDbContext dbContext)
    {
        return dbContext.ProductCategories
            .Include(c=>c.Products);
    } 
    
    public static ProductCategory? GetProductCategoryById(AppDbContext dbContext, Guid id)
    {
        return dbContext.ProductCategories
            .Include(c=>c.Products)
            .SingleOrDefault(p => p.Id == id);
    }
}