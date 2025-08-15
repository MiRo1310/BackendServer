using Rezepte.Data;
using Rezepte.Models;
using Rezepte.Models.Recipe;

namespace Rezepte.Types;

public static class RecipeProductsHelper
{
    public static void ProcessProducts(AppDbContext dbContext, Recipe recipe,
        ICollection<RecipeProductsCreateDto?> products)
    {
        foreach (var recipeProduct in products)
        {
            if (recipeProduct is null) continue;
            if (recipeProduct.Id is null)
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

                dbContext.RecipeProducts.Add(product);
                continue;
            }

            var productUpdate = dbContext.RecipeProducts.FirstOrDefault(header => header.Id == recipeProduct.Id);
            if (productUpdate is null) continue;

            productUpdate.Amount = recipeProduct.Amount;
            productUpdate.Unit = recipeProduct.Unit ?? productUpdate.Unit;
            productUpdate.Factor = recipeProduct.Factor;
            productUpdate.Description = recipeProduct.Description ?? productUpdate.Description;
            productUpdate.ProductId = recipeProduct.ProductId;
            productUpdate.ProductPosition = recipeProduct.ProductPosition;
            productUpdate.GroupPosition = recipeProduct.GroupPosition;
            productUpdate.ModifiedAt = DateTime.UtcNow;
        }
    }
}