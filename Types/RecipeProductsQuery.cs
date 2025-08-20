using System.ComponentModel.DataAnnotations.Schema;
using BackendServer.Data;
using BackendServer.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Types;

[Table("recipeProducts")]

public static class RecipeProductsQuery
{
    public static IQueryable<RecipeProduct> GetRecipeProducts(AppDbContext dbContext)
    {
        return dbContext.RecipeProducts
            .Include(product => product.ProductUnits);
    }
}