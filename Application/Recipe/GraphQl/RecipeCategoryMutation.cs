using BackendServer.Application.Common;
using BackendServer.Data;
using BackendServer.Enum;
using BackendServer.Models.DTOs.Recipes.RecipeCategory;
using BackendServer.Models.Entities.Recipes;

namespace BackendServer.Application.Recipe.GraphQl;

[MutationType]
public static class RecipeCategoryMutation
{
    public static RecipeCategory? CreateRecipeCategory(AppDbContext dbContext,
        RecipeCategoryCreateDto dto)
    {
        var category = dbContext.RecipeCategories.FirstOrDefault(category => category.Name == dto.Name);

        if (category is not null)
        {
            GraphQlErrorHandler.Custom("Kategorie existiert bereits", ErrorCode.Exist);
            return null;
        }

        var recipeCategory = new RecipeCategory()
        {
            CreatedAt = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Name = dto.Name
        };
        dbContext.RecipeCategories.Add(recipeCategory);
        dbContext.SaveChanges();

        return recipeCategory;
    }

    public static bool RemoveRecipeCategory(AppDbContext dbContext, Guid id)
    {
        var recipeCategory = dbContext.RecipeCategories.FirstOrDefault(category => category.Id == id);

        if (recipeCategory is null)
        {
            GraphQlErrorHandler.Custom("Kategorie wurde nicht gefunden", ErrorCode.NotFound);
            return false;
        }

        if (dbContext.Recipes.Any(r => r.RecipeCategoryId == id))
        {
            GraphQlErrorHandler.Custom("Kategorie kann nicht gelöscht werden", ErrorCode.InUse);
            return false;
        }

        dbContext.RecipeCategories.Remove(recipeCategory);
        dbContext.SaveChanges();

        return true;
    }


    public static RecipeCategory? UpdateRecipeCategory(AppDbContext dbContext, RecipeCategoryUpdateDto dto)
    {
        var recipeCategory = dbContext.RecipeCategories.FirstOrDefault(category => category.Id == dto.Id);

        if (recipeCategory is null) return null;

        recipeCategory.Name = dto.Name;

        dbContext.SaveChanges();
        return recipeCategory;
    }
}