using Rezepte.Data;
using Rezepte.Models;
using Rezepte.Models.Recipe;

namespace Rezepte.Types;

public static class RecipeHeaderProductsHelper
{
    public static void ProcessProductsHeader(AppDbContext dbContext, Recipe recipe,
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
                
                dbContext.ProductHeaders.Add(productHeader);
                continue;
            }

            var headerProduct = dbContext.ProductHeaders.FirstOrDefault(header => header.Id == recipeHeaderProduct.Id);
            if (headerProduct is null) continue;

            headerProduct.Text = recipeHeaderProduct.Text;
            headerProduct.Position = recipeHeaderProduct.Position;
            headerProduct.ModifiedAt = DateTime.UtcNow;
        }
    }
}