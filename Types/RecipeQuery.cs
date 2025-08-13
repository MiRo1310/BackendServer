using Microsoft.EntityFrameworkCore;
using Rezepte.Data;
using Rezepte.Models;

namespace Rezepte.Types;

[QueryType]
public static class RecipeQuery
{
    public static IQueryable<Recipe> GetRecipes(AppDbContext dbContext)
    {
        return dbContext.Recipes
            .Include(recipe => recipe.Headers)
            .Include(recipe => recipe.RecipeProducts)
            .Include(recipe => recipe.RecipeImages);
    }

    public static Recipe? GetRecipe(AppDbContext dbContext, Guid id)
    {
        return dbContext.Recipes
            .Include(recipe => recipe.Headers)
            .Include(recipe => recipe.RecipeProducts)
            .Include(recipe => recipe.RecipeImages)
            .FirstOrDefault(recipe => recipe.Id == id);
    }

}