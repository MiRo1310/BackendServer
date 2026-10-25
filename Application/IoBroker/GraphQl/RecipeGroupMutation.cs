using BackendServer.Data;
using BackendServer.Models.DTOs.IoBroker;

namespace BackendServer.Application.IoBroker.GraphQl;

[MutationType]
public static class RecipeGroupMutation
{
    public static bool RemoveProductGroup(AppDbContext dbContext, RecipeGroupRemoveDto dto)
    {
        var headers =
            dbContext.RecipeProductHeaders.Where(header =>
                header.RecipeId == dto.RecipeId && header.Position == dto.Position);
        var products = dbContext.RecipeProducts.Where(product =>
            product.RecipeId == dto.RecipeId && product.GroupPosition == dto.Position);
        
        foreach (var recipeHeaderProduct in headers)
        {
            dbContext.RecipeProductHeaders.Remove(recipeHeaderProduct);
        }
        
        foreach (var recipeProduct in products)
        {
            dbContext.RecipeProducts.Remove(recipeProduct);
        }

        dbContext.SaveChanges();
        return true;
    }
}