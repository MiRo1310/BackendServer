using BackendServer.Data;
using BackendServer.Models.Recipe;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Types;

[QueryType]
public static class RecipeQuery
{
    public static IQueryable<Recipe> GetRecipes(AppDbContext dbContext)
    {
        return dbContext.Recipes
            .Include(recipe => recipe.RecipeProducts)
                .ThenInclude(rp=> rp.Product)
            .Include(recipe => recipe.RecipeDescriptions)
            .Include(recipe => recipe.RecipeHeaderProducts);
    }

    public static Recipe? GetRecipe(AppDbContext dbContext, Guid id)
    {
        return dbContext.Recipes
            .Include(recipe => recipe.RecipeProducts)
                .ThenInclude(rp=> rp.Product)
            .Include(recipe => recipe.RecipeDescriptions)
            .Include(recipe => recipe.RecipeHeaderProducts)
            .FirstOrDefault(recipe => recipe.Id == id);
    }
}