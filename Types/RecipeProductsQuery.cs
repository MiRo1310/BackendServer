using BackendServer.Data;
using BackendServer.Models.RecipeProduct;

namespace BackendServer.Types;

public static class RecipeProductsQuery
{
    public static IQueryable<RecipeProduct> GetRecipeProducts(AppDbContext dbContext)
    {
        return dbContext.RecipeProducts;
    }
}