using Rezepte.Data;
using Rezepte.Models;

namespace Rezepte.Types;

public static class RecipeHeaderProductsHelper
{
    public static void ProcessProducts(AppDbContext dbContext, Recipe recipe,
        ICollection<RecipeHeaderProductCreateOrUpdateDto?> headerProducts)
    {
        foreach (var recipeHeaderProduct in headerProducts)
        {
            if (recipeHeaderProduct is null) continue;
            if (recipeHeaderProduct.Id is null)
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
                continue;
            }

            var productUpdate = dbContext.ProductHeaders.FirstOrDefault(header => header.Id == recipeHeaderProduct.Id);
            if (productUpdate is null) continue;

            productUpdate.Text = recipeHeaderProduct.Text;
            productUpdate.Position = recipeHeaderProduct.Position;
            productUpdate.ModifiedAt = DateTime.UtcNow;
        }
    }
}