using BackendServer.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Application.Recipe.GraphQl;

[QueryType]
public static class RecipeQuery
{
    public static IQueryable<Models.Entities.Recipes.Recipe> GetRecipes(AppDbContext dbContext)
    {
        return dbContext.Recipes
            .Include(recipe => recipe.RecipeProducts)
                .ThenInclude(rp=> rp.Product)
            .Include(recipe => recipe.RecipeDescriptions)
            .Include(recipe => recipe.RecipeHeaderProducts);
    }

    public static Models.Entities.Recipes.Recipe? GetRecipe(AppDbContext dbContext, Guid id)
    {
        return dbContext.Recipes
            .Include(recipe => recipe.RecipeProducts)
                .ThenInclude(rp=> rp.Product)
            .Include(recipe => recipe.RecipeDescriptions)
            .Include(recipe => recipe.RecipeHeaderProducts)
            .FirstOrDefault(recipe => recipe.Id == id);
    }
}