using BackendServer.Application.Recipe.Factories;
using BackendServer.Data;
using BackendServer.Models.DTOs.Recipes.Recipe;

namespace BackendServer.Application.Recipe.GraphQl;

[MutationType]
public static class RecipeMutation
{
    public static bool RemoveRecipe(AppDbContext dbContext, Guid id)
    {
        var recipe = dbContext.Recipes.FirstOrDefault(recipe => recipe.Id == id);
        if (recipe is null) return false;
        
        RecipeProductsFactory.RemoveByRecipeId(dbContext, recipe.Id);
        RecipeDescriptionFactory.RemoveDescription(dbContext, recipe.Id);
        RecipeProductHeaderFactory.RemoveProductHeader(dbContext, recipe.Id);
        
        dbContext.Recipes.Remove(recipe);
        dbContext.SaveChanges();
        return true;
    }

    public static Models.Entities.Recipes.Recipe CreateRecipe(AppDbContext dbContext, RecipeCreateDto dto)
    {
        var recipe = new Models.Entities.Recipes.Recipe
        {
            CreatedAt = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Portions = dto.Portions,
            RecipeCategoryId = dto.RecipeCategoryId,
            PreparationTimeMin = dto.PreparationTimeMin,
            TotalTimeMin = dto.TotalTimeMin,
        };

        if (dto.RecipeProducts != null)
            RecipeProductsFactory.ProcessProducts(dbContext, recipe, dto.RecipeProducts);

        if (dto.RecipeDescriptions != null)
            RecipeDescriptionFactory.ProcessDescription(dbContext, recipe, dto.RecipeDescriptions);

        if (dto.RecipeHeaderProducts != null)
            RecipeProductHeaderFactory.ProcessProductsHeader(dbContext, recipe, dto.RecipeHeaderProducts);
        
        dbContext.Recipes.Add(recipe);
        
        dbContext.SaveChanges();
        
        RecipeFactory.SetTotalKcalByRecipeId(dbContext, recipe.Id);
        return recipe;
    }

    public static Models.Entities.Recipes.Recipe? UpdateRecipe(AppDbContext dbContext, RecipeUpdateDto dto)
    {
        var recipe = dbContext.Recipes.FirstOrDefault(recipe => recipe.Id == dto.Id);
        if (recipe is null) return null;

        recipe.Name = dto.Name ?? recipe.Name;
        recipe.Portions = dto.Portions ?? recipe.Portions;
        recipe.ModifiedAt = DateTime.UtcNow;
        recipe.RecipeCategoryId = dto.RecipeCategoryId ?? recipe.RecipeCategoryId;
        recipe.PreparationTimeMin = dto.PreparationTimeMin;
        recipe.TotalTimeMin = dto.TotalTimeMin;

        if (dto.RecipeProducts is not null)
            RecipeProductsFactory.ProcessProducts(dbContext, recipe, dto.RecipeProducts);

        if (dto.RecipeHeaderProducts is not null)
            RecipeProductHeaderFactory.ProcessProductsHeader(dbContext, recipe, dto.RecipeHeaderProducts);

        if (dto.RecipeDescriptions is not null)
            RecipeDescriptionFactory.ProcessDescription(dbContext, recipe, dto.RecipeDescriptions);

        
        dbContext.SaveChanges();
        
        RecipeFactory.SetTotalKcalByRecipeId(dbContext, dto.Id);
        
        return recipe;
    }
}