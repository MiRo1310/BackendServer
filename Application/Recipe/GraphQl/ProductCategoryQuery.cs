using BackendServer.Data;
using BackendServer.Models.Entities.Recipes;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Application.Recipe.GraphQl;

[QueryType]

public static class ProductCategoryQuery
{
    [UseSorting]
    [UseFiltering]
    public static IQueryable<ProductCategory> GetProductCategories(AppDbContext dbContext)
    {
        return dbContext.ProductCategories
            .Include(c=>c.Products)
            .OrderBy(c=>c.Name);
    } 
    
    public static ProductCategory? GetProductCategoryById(AppDbContext dbContext, Guid id)
    {
        return dbContext.ProductCategories
            .Include(c=>c.Products)
            .SingleOrDefault(p => p.Id == id);
    }
}