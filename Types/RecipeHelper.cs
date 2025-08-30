using BackendServer.Data;
using BackendServer.Models.RecipeProduct;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Types;

public static class RecipeHelper
{
    public static void SetTotalKcalByRecipeId(AppDbContext dbContext, Guid recipeId)
    {
        var recipe = dbContext.Recipes
            .Include(r=>r.RecipeProducts)
            .FirstOrDefault(recipe => recipe.Id == recipeId);
        if (recipe is null)
        {
            return;
        }

        recipe.TotalKcal = recipe.RecipeProducts.Sum(rp => rp!.Kcal);

        dbContext.SaveChanges();
    }
}