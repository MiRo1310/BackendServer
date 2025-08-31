using BackendServer.Data;
using BackendServer.Models.RecipeProduct;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Types;

public static class RecipeProductsQuery
{
    public static IQueryable<RecipeProduct> GetRecipeProducts(AppDbContext dbContext)
    {
        return dbContext.RecipeProducts
            .Include(product => product.Product );
    }
}