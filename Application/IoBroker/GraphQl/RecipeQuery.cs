using BackendServer.Data;
using BackendServer.Models.Entities.IoBroker;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Application.IoBroker.GraphQl;

[QueryType]
public static class RecipeQuery
{
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Recipe> GetRecipes(AppDbContext dbContext)
    {
        return dbContext.Recipes
            .Include(recipe => recipe.RecipeProducts)
                .ThenInclude(rp=> rp.Product)
                .ThenInclude(p => p!.Unit)
            .Include(recipe => recipe.RecipeDescriptions)
            .Include(recipe => recipe.RecipeHeaderProducts)
            .Include(recipe => recipe.RecipeCategory);
    }

    public static Recipe? GetRecipe(AppDbContext dbContext, Guid id)
    {
        return dbContext.Recipes
            .Include(recipe => recipe.RecipeProducts)
                .ThenInclude(rp=> rp.Product)
                .ThenInclude(p => p!.Unit)
            .Include(recipe => recipe.RecipeDescriptions)
            .Include(recipe => recipe.RecipeHeaderProducts)
            .Include(recipe => recipe.RecipeCategory)
            .FirstOrDefault(recipe => recipe.Id == id);
    }
}