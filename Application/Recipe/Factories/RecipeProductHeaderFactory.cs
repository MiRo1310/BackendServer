using BackendServer.Data;
using BackendServer.Models.Entities.Recipes;
using BackendServer.Models.RecipeProductHeader;

namespace BackendServer.Application.Recipe.Factories;

public static class RecipeProductHeaderFactory
{
    public static void ProcessProductsHeader(AppDbContext dbContext, Models.Entities.Recipes.Recipe recipe,
        ICollection<RecipeHeaderProductCreateOrUpdateDto?> headerProducts)
    {
        foreach (var recipeHeaderProduct in headerProducts)
        {
            if (recipeHeaderProduct is null) continue;
            if (recipeHeaderProduct.Id is null)
            {
                var productHeader = new RecipeProductHeader
                {
                    CreatedAt = DateTime.UtcNow,
                    Id = Guid.NewGuid(),
                    RecipeId = recipe.Id,
                    Position = recipeHeaderProduct.Position,
                    Text = recipeHeaderProduct.Text,
                    Recipe = null
                };
                
                dbContext.RecipeProductHeaders.Add(productHeader);
                continue;
            }

            var headerProduct = dbContext.RecipeProductHeaders.FirstOrDefault(header => header.Id == recipeHeaderProduct.Id);
            if (headerProduct is null) continue;

            headerProduct.Text = recipeHeaderProduct.Text;
            headerProduct.Position = recipeHeaderProduct.Position;
            headerProduct.ModifiedAt = DateTime.UtcNow;
        }
    }


    public static void RemoveProductHeader(AppDbContext dbContext, Guid recipeId)
    {
        var productHeaders = dbContext.RecipeProductHeaders.Where(d => d.RecipeId == recipeId);

        if (!productHeaders.Any()) return;
        
        dbContext.RecipeProductHeaders.RemoveRange(productHeaders);
        dbContext.SaveChanges();
    }
}