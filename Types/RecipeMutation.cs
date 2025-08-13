using Rezepte.Data;
using Rezepte.Models;

namespace Rezepte.Types;
[MutationType]
public static class RecipeMutation
{
    public static bool DeleteRecipe(AppDbContext dbContext, Guid id)
    {
        var recipe = dbContext.Recipes.FirstOrDefault(recipe => recipe.Id == id);
        if (recipe is null)
        {
            return false;
        }

        dbContext.Recipes.Remove(recipe);
        dbContext.SaveChanges();
        return true;
    }

    public static Recipe CreateRecipe(AppDbContext dbContext, RecipeCreateDto dto )
    {
        var recipe = new Recipe()
        {
            CreatedAt = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Portions = dto.Portions
        };
        dbContext.Recipes.Add(recipe);
        dbContext.SaveChanges();
        return recipe;
    }

    public static Recipe? UpdateRecipe(AppDbContext dbContext, RecipeUpdateDto dto)
    {
        var recipe = dbContext.Recipes.FirstOrDefault(recipe => recipe.Id == dto.Id);
        if (recipe is null)
        {
            return null;
        }

        recipe.Name = dto.Name ?? recipe.Name;
        recipe.Portions = dto.Portions ?? recipe.Portions;
        recipe.ModifiedAt = DateTime.UtcNow;
        
        dbContext.SaveChanges();
        return recipe;
    }
}