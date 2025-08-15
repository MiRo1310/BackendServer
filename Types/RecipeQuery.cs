using Microsoft.EntityFrameworkCore;
using Rezepte.Data;
using Rezepte.Models.Recipe;

namespace Rezepte.Types;

[QueryType]
public static class RecipeQuery
{
    public static IQueryable<Recipe> GetRecipes(AppDbContext dbContext)
    {
        return dbContext.Recipes
            .Include(recipe => recipe.RecipeProducts)
            .Include(recipe => recipe.RecipeDescriptions)
            .Include(recipe => recipe.RecipeHeaderProducts);
    }

    public static Recipe? GetRecipe(AppDbContext dbContext, Guid id)
    {
        return dbContext.Recipes
            .Include(recipe => recipe.RecipeProducts)
            .Include(recipe => recipe.RecipeDescriptions)
            .Include(recipe => recipe.RecipeHeaderProducts)
            .FirstOrDefault(recipe => recipe.Id == id);
    }
}