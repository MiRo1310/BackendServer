using BackendServer.Data;
using BackendServer.Enum;
using BackendServer.Models;
using BackendServer.Models.DTOs;
using BackendServer.Models.DTOs.Recipes.RecipeCategory;
using BackendServer.Models.Entities.Recipes;

namespace BackendServer.Application.Recipe.GraphQl;

[MutationType]
public static class RecipeCategoryMutation
{
    public static Response<RecipeCategory> CreateRecipeCategory(AppDbContext dbContext,
        RecipeCategoryCreateDto dto)
    {
        var category = dbContext.RecipeCategories.FirstOrDefault(category => category.Name == dto.Name);

        if (category is not null)
            return new Response<RecipeCategory>(null, ErrorCode.Exist, true);

        var recipeCategory = new RecipeCategory()
        {
            CreatedAt = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Name = dto.Name
        };
        dbContext.RecipeCategories.Add(recipeCategory);
        dbContext.SaveChanges();

        return new Response<RecipeCategory>(recipeCategory, ErrorCode.Success);
    }

    public static bool RemoveRecipeCategory(AppDbContext dbContext, Guid id)
    {
        var recipeCategory = dbContext.RecipeCategories.FirstOrDefault(category => category.Id == id);

        if (recipeCategory is null) return false;

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