using BackendServer.Application.Common;
using BackendServer.Application.Enum;
using BackendServer.Application.IoBroker.Factories;
using BackendServer.Data;
using BackendServer.Models.DTOs.IoBroker;
using BackendServer.Models.DTOs.IoBroker.Recipe;
using BackendServer.Models.Entities.IoBroker;

namespace BackendServer.Application.IoBroker.GraphQl;

[MutationType]
public static class RecipeMutation
{
    public static bool RemoveRecipe(AppDbContext dbContext, Guid id)
    {
        var recipe = dbContext.Recipes.FirstOrDefault(recipe => recipe.Id == id);
        if (recipe is null)
        {
            GraphQlErrorHandler.Custom("Rezept wurde nicht gefunden", ErrorCode.NotFound);
            return false;
        }

        RecipeProductsFactory.RemoveByRecipeId(dbContext, recipe.Id);
        RecipeDescriptionFactory.RemoveDescription(dbContext, recipe.Id);
        RecipeProductHeaderFactory.RemoveProductHeader(dbContext, recipe.Id);

        dbContext.Recipes.Remove(recipe);
        dbContext.SaveChanges();
        return true;
    }

    public static Recipe CreateRecipe(AppDbContext dbContext, RecipeCreateDto dto)
    {
        var recipe = new Recipe
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

    public static Recipe? UpdateRecipe(AppDbContext dbContext, RecipeUpdateDto dto)
    {
        using var transaction = dbContext.Database.BeginTransaction();
        var recipe = dbContext.Recipes.FirstOrDefault(recipe => recipe.Id == dto.Id);

        if (recipe is null)
        {
            GraphQlErrorHandler.Custom("Rezept wurde nicht gefunden", ErrorCode.NotFound);
            return null;
        }

        RemoveTextarea(dbContext, dto.RemovedStepIds ?? [], dto.Id);
        RemoveRecipeProduct(dbContext, dto.RemovedRecipeProductIds ?? [], dto.Id);
        RemoveRecipeProductGroup(dbContext, dto.RemovedGroupPositions ?? [], dto.Id);

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
        transaction.Commit();
        return recipe;
    }

    public static Recipe? MarkRecipeCooked(AppDbContext dbContext, Guid recipeId)
    {
        var recipe = dbContext.Recipes.FirstOrDefault(recipe => recipe.Id == recipeId);
        
        if (recipe is null)
        {
            GraphQlErrorHandler.Custom("Rezept wurde nicht gefunden", ErrorCode.NotFound);
            return null;
        }
        
        recipe.LastCookedAt = DateTime.UtcNow;
        recipe.CookedCount++;
        
        dbContext.SaveChanges();
        return recipe;
    }

    private static void RemoveTextarea(AppDbContext dbContext, List<Guid> removedStepIds, Guid recipeId)
    {
        foreach (var id in removedStepIds)
        {
            RecipeMutationHelper.RemoveTextarea(dbContext, id, recipeId);
        }
    }

    private static void RemoveRecipeProduct(AppDbContext dbContext, List<Guid> removedProductRecipeIds, Guid recipeId)
    {
        foreach (var id in removedProductRecipeIds)
        {
            RecipeMutationHelper.RemoveRecipeProduct(dbContext, id, recipeId);
        }
    }

    private static void RemoveRecipeProductGroup(AppDbContext dbContext, List<int> removedRecipeProductGroups,
        Guid recipeId)
    {
        foreach (var position in removedRecipeProductGroups)
        {
            RecipeMutationHelper.RemoveProductGroup(dbContext,
                new RecipeGroupRemoveDto { RecipeId = recipeId, Position = position });
        }
    }
}