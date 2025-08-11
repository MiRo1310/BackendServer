using Rezepte.Data;
using Rezepte.Models;

namespace Rezepte.Types;

[QueryType]
public static class RecipeQuery
{
    public static IQueryable<Recipe> GetRecipes(AppDbContext dbContext)
    {
        return dbContext.Recipes;
    }

    public static Recipe? GetRecipe(AppDbContext dbContext, Guid id)
    {
        return dbContext.Recipes.FirstOrDefault(recipe => recipe.Id == id);
    }
    
}