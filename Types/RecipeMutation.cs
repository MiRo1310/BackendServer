using Rezepte.Data;
using Rezepte.Models;

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
            foreach (var recipeHeader in dto.RecipeHeaders)
            {
                var header = new RecipeHeader
                {
                    CreatedAt = DateTime.UtcNow,
                    Id = Guid.NewGuid(),
                    Position = recipeHeader.Position,
                    RecipeId = recipe.Id,
                    Text = recipeHeader.Text
                };
                recipe.Headers.Add(header);
            }

        if (dto.RecipeProducts != null)
            foreach (var recipeProduct in dto.RecipeProducts)
            {
                var product = new RecipeProduct
                {
                    CreatedAt = DateTime.UtcNow,
                    Id = Guid.NewGuid(),
                    RecipeId = recipe.Id,
                    Amount = recipeProduct.Amount,
                    Unit = recipeProduct.Unit ?? "",
                    Factor = recipeProduct.Factor,
                    Description = recipeProduct.Description ?? "",
                    ProductId = recipeProduct.ProductId,
                    ProductPosition = recipeProduct.ProductPosition,
                    GroupPosition = recipeProduct.GroupPosition
                };
                // dbContext.RecipeProducts.Add(product);
                recipe.RecipeProducts.Add(product);
            }

        if (dto.RecipeTextAreas != null)
            foreach (var recipeTextArea in dto.RecipeTextAreas)
            {
                var textArea = new RecipeTextArea
                {
                    CreatedAt = DateTime.UtcNow,
                    Id = Guid.NewGuid(),
                    RecipeId = recipe.Id,
                    Position = recipeTextArea.Position,
                    Text = recipeTextArea.Text
                };
                // dbContext.RecipeTextAreas.Add(textArea);
                recipe.RecipeTextAreas.Add(textArea);
            }

        if (dto.RecipeHeaderProducts != null)
            foreach (var recipeHeaderProduct in dto.RecipeHeaderProducts)
            {
                var productHeader = new RecipeHeaderProduct
                {
                    CreatedAt = DateTime.UtcNow,
                    Id = Guid.NewGuid(),
                    RecipeId = recipe.Id,
                    Position = recipeHeaderProduct.Position,
                    Text = recipeHeaderProduct.Text
                };
                // dbContext.ProductHeaders.Add(productHeader);
                recipe.RecipeHeaderProducts.Add(productHeader);
            }

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

        if (dto.RecipeHeaders != null)
            foreach (var recipeHeader in dto.RecipeHeaders)
            {
                if (recipeHeader.Id is null)
                {
                    var header = new RecipeHeader
                    {
                        CreatedAt = DateTime.UtcNow,
                        Id = Guid.NewGuid(),
                        Position = recipeHeader.Position,
                        RecipeId = recipe.Id,
                        Text = recipeHeader.Text
                    };
                    recipe.Headers.Add(header);
                }

                if (recipeHeader.Id is not null)
                {
                    var header = dbContext.RecipeHeaders.FirstOrDefault(header => header.Id == recipeHeader.Id);

                    header.Position = recipeHeader.Position;
                    header.Text = recipeHeader.Text;
                    header.ModifiedAt = DateTime.UtcNow;
                }
            }

        dbContext.SaveChanges();
        return recipe;
    }
}