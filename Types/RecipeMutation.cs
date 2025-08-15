using Rezepte.Data;
using Rezepte.Models;
using Rezepte.Models.Recipe;

namespace Rezepte.Types;

[MutationType]
public static class RecipeMutation
{
    public static bool RemoveRecipe(AppDbContext dbContext, Guid id)
    {
        var recipe = dbContext.Recipes.FirstOrDefault(recipe => recipe.Id == id);
        if (recipe is null) return false;

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
            Portions = dto.Portions
        };

        if (dto.RecipeHeaders != null)
            RecipeHeaderHelper.ProcessHeaders(dbContext, recipe, dto.RecipeHeaders);

        if (dto.RecipeProducts != null)
            RecipeProductsHelper.ProcessProducts(dbContext, recipe, dto.RecipeProducts);
        
        if (dto.RecipeTextAreas != null)
            RecipeDescriptionHelper.ProcessTextareas(dbContext, recipe, dto.RecipeTextAreas);
           
        if (dto.RecipeHeaderProducts != null)
            RecipeHeaderProductsHelper.ProcessProductsHeader(dbContext, recipe, dto.RecipeHeaderProducts);
            
        dbContext.Recipes.Add(recipe);
        dbContext.SaveChanges();
        return recipe;
    }

    public static Recipe? UpdateRecipe(AppDbContext dbContext, RecipeUpdateDto dto)
    {
        var recipe = dbContext.Recipes.FirstOrDefault(recipe => recipe.Id == dto.Id);
        if (recipe is null) return null;

        recipe.Name = dto.Name ?? recipe.Name;
        recipe.Portions = dto.Portions ?? recipe.Portions;
        recipe.ModifiedAt = DateTime.UtcNow;
        
        if (dto.RecipeHeaders is not null)
            RecipeHeaderHelper.ProcessHeaders(dbContext, recipe, dto.RecipeHeaders);
        
        if (dto.RecipeProducts is not null)
            RecipeProductsHelper.ProcessProducts(dbContext, recipe, dto.RecipeProducts);
        
        if (dto.RecipeHeaderProducts is not null)
            RecipeHeaderProductsHelper.ProcessProductsHeader(dbContext, recipe, dto.RecipeHeaderProducts);
        
        if (dto.RecipeTextAreas is not null)
            RecipeDescriptionHelper.ProcessTextareas(dbContext,recipe,dto.RecipeTextAreas);
        
        dbContext.SaveChanges();
               
        return recipe;
    }
}