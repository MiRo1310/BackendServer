using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Rezepte.Data;
using Rezepte.Models;

namespace Rezepte.Types;

[Table("recipeProducts")]

public static class RecipeProductsQuery
{
    public static IQueryable<RecipeProduct> GetRecipeProducts(AppDbContext dbContext)
    {
        return dbContext.RecipeProducts
            .Include(product => product.ProductUnits);
    }
}