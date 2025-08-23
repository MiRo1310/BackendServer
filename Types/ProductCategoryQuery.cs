using BackendServer.Data;
using BackendServer.Models.ProductCategory;

namespace BackendServer.Types;

[QueryType]

public static class ProductCategoryQuery
{
    public static IQueryable<ProductCategory> GetProductCategories(AppDbContext dbContext)
    {
        return dbContext.ProductCategories;
    } 
}