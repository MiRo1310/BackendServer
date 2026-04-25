using BackendServer.Data;
using BackendServer.Models.Entities.Recipes;

namespace BackendServer.Application.Recipe.GraphQl;

[QueryType]

public static class RecipeCategoryQuery
{
    [UseSorting]
    [UseFiltering]
    public static IQueryable<RecipeCategory> GetRecipeCategories(AppDbContext dbContext)
    {
        return dbContext.RecipeCategories
            .OrderBy(c=>c.Name);
    } 
    
    public static RecipeCategory? GetRecipeCategoryById(AppDbContext dbContext, Guid id)
    {
        return dbContext.RecipeCategories
            .SingleOrDefault(p => p.Id == id);
    }
}