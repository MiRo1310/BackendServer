using BackendServer.Data;
using BackendServer.Models.Entities.Recipes;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Application.Recipe.GraphQl;

[QueryType]
public static class RecipeProductsQuery
{
    public static IQueryable<RecipeProduct> GetRecipeProducts(AppDbContext dbContext)
    {
        return dbContext.RecipeProducts
            .Include(product => product.Product );
    }
}