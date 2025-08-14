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
// TODO macht man das so, das das Backend alles macht aufbauend auf der Id die erstellt wurde? Sollte ich das alles in weitere Klassen auslagern?
        if (dto.RecipeHeaders != null)
            RecipeHeaderHelper.ProcessHeaders(dbContext, recipe, dto.RecipeHeaders);

        // foreach (var recipeHeader in dto.RecipeHeaders)
        // {
        //     if (recipeHeader is null) continue;
        //     var header = new RecipeHeader
        //     {
        //         CreatedAt = DateTime.UtcNow,
        //         Id = Guid.NewGuid(),
        //         Position = recipeHeader.Position,
        //         RecipeId = recipe.Id,
        //         Text = recipeHeader.Text
        //     };
        //     recipe.Headers.Add(header);
        // }

        if (dto.RecipeProducts != null)
            RecipeProductsHelper.ProcessProducts(dbContext, recipe, dto.RecipeProducts);
        // foreach (var recipeProduct in dto.RecipeProducts)
        // {
        //     if (recipeProduct is null) continue;
        //     var product = new RecipeProduct
        //     {
        //         CreatedAt = DateTime.UtcNow,
        //         Id = Guid.NewGuid(),
        //         RecipeId = recipe.Id,
        //         Amount = recipeProduct.Amount,
        //         Unit = recipeProduct.Unit ?? "",
        //         Factor = recipeProduct.Factor,
        //         Description = recipeProduct.Description ?? "",
        //         ProductId = recipeProduct.ProductId,
        //         ProductPosition = recipeProduct.ProductPosition,
        //         GroupPosition = recipeProduct.GroupPosition
        //     };
        //     // dbContext.RecipeProducts.Add(product);
        //     recipe.RecipeProducts.Add(product);
        // }

        if (dto.RecipeTextAreas != null)
            RecipeTextAreaHelper.ProcessProducts(dbContext, recipe, dto.RecipeTextAreas);
            // foreach (var recipeTextArea in dto.RecipeTextAreas)
            // {
            //     if (recipeTextArea is null) continue;
            //     var textArea = new RecipeTextArea
            //     {
            //         CreatedAt = DateTime.UtcNow,
            //         Id = Guid.NewGuid(),
            //         RecipeId = recipe.Id,
            //         Position = recipeTextArea.Position,
            //         Text = recipeTextArea.Text
            //     };
            //     // dbContext.RecipeTextAreas.Add(textArea);
            //     recipe.RecipeTextAreas.Add(textArea);
            // }

        if (dto.RecipeHeaderProducts != null)
            RecipeHeaderProductsHelper.ProcessProducts(dbContext, recipe, dto.RecipeHeaderProducts);
            // foreach (var recipeHeaderProduct in dto.RecipeHeaderProducts)
            // {
            //     if (recipeHeaderProduct is null) continue;
            //     var productHeader = new RecipeHeaderProduct
            //     {
            //         CreatedAt = DateTime.UtcNow,
            //         Id = Guid.NewGuid(),
            //         RecipeId = recipe.Id,
            //         Position = recipeHeaderProduct.Position,
            //         Text = recipeHeaderProduct.Text
            //     };
            //     // dbContext.ProductHeaders.Add(productHeader);
            //     recipe.RecipeHeaderProducts.Add(productHeader);
            // }

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
            RecipeHeaderHelper.ProcessHeaders(dbContext, recipe, dto.RecipeHeaders);


        // foreach (var recipeHeader in dto.RecipeHeaders)
        // {
        //     if (recipeHeader is null)
        //     {
        //         continue;
        //     }
        //     
        //     if (recipeHeader.Id is null)
        //     {
        //         var header = new RecipeHeader
        //         {
        //             CreatedAt = DateTime.UtcNow,
        //             Id = Guid.NewGuid(),
        //             Position = recipeHeader.Position,
        //             RecipeId = recipe.Id,
        //             Text = recipeHeader.Text
        //         };
        //         recipe.Headers.Add(header);
        //         continue;
        //     }
        //
        //
        //     var headerUpdate = dbContext.RecipeHeaders.FirstOrDefault(header => header.Id == recipeHeader.Id);
        //     if (headerUpdate is null) continue;
        //     headerUpdate.Position = recipeHeader.Position;
        //     headerUpdate.Text = recipeHeader.Text;
        //     headerUpdate.ModifiedAt = DateTime.UtcNow;
        // }

        if (dto.RecipeProducts != null)
            RecipeProductsHelper.ProcessProducts(dbContext, recipe, dto.RecipeProducts);
        
        if (dto.RecipeHeaderProducts != null)
            RecipeHeaderProductsHelper.ProcessProducts(dbContext, recipe, dto.RecipeHeaderProducts);

        dbContext.SaveChanges();
        return recipe;
    }
}