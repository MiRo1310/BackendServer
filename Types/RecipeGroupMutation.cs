using Rezepte.Data;
using Rezepte.Models.RecipeGroup;

namespace Rezepte.Types;

[MutationType]
public static class RecipeGroupMutation
{
    public static bool RemoveProductGroup(AppDbContext dbContext, RecipeGroupRemoveDto dto)
    {
        var headers =
            dbContext.ProductHeaders.Where(header =>
                header.RecipeId == dto.RecipeId && header.Position == dto.Position);
        var products = dbContext.RecipeProducts.Where(product =>
            product.RecipeId == dto.RecipeId && product.GroupPosition == dto.Position);
        
        foreach (var recipeHeaderProduct in headers)
        {
            dbContext.ProductHeaders.Remove(recipeHeaderProduct);
        }
        
        foreach (var recipeProduct in products)
        {
            dbContext.RecipeProducts.Remove(recipeProduct);
        }

        dbContext.SaveChanges();
        return true;
    }
}