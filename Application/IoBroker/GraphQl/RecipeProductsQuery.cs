using BackendServer.Data;
using BackendServer.Models.Entities.IoBroker;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Application.IoBroker.GraphQl;

[QueryType]
public static class RecipeProductsQuery
{
    public static IQueryable<RecipeProduct> GetRecipeProducts(AppDbContext dbContext)
    {
        return dbContext.RecipeProducts
            .Include(product => product.Product );
    }
}