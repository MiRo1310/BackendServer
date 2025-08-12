using Rezepte.Data;
using Rezepte.Models;

namespace Rezepte.Types;

[QueryType]

public static class ProductCategoryQuery
{
    public static IQueryable<ProductCategory> GetProductCategories(AppDbContext dbContext)
    {
        return dbContext.ProductCategories;
    } 
}