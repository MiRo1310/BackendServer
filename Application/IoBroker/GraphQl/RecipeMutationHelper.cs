using BackendServer.Application.Common;
using BackendServer.Application.Enum;
using BackendServer.Application.IoBroker.Factories;
using BackendServer.Data;
using BackendServer.Models.DTOs.IoBroker;

namespace BackendServer.Application.IoBroker.GraphQl;

public class RecipeMutationHelper
{
    public static bool RemoveTextarea(AppDbContext dbContext, Guid id, Guid? recipeId = null)
    {
        var textarea = dbContext.RecipeDescriptions.FirstOrDefault(textarea => textarea.Id == id);

        if (textarea is null)
        {
            GraphQlErrorHandler.Custom("Beschreibung wurde nicht gefunden", ErrorCode.NotFound);
            return false;
        }

        if (recipeId is not null && textarea.RecipeId != recipeId)
        {
            GraphQlErrorHandler.Custom("Beschreibung gehört nicht zum Rezept", ErrorCode.NotContains);
            return false;
        }

        dbContext.RecipeDescriptions.Remove(textarea);
        dbContext.SaveChanges();
     
        DescriptionFactory.ResetPositions(dbContext, textarea.RecipeId);

        return true;
    }

    public static bool RemoveRecipeProduct(AppDbContext dbContext, Guid id, Guid? recipeId = null)
    {
        var recipeProduct = dbContext.RecipeProducts.FirstOrDefault(product => product.Id == id);
          
        if(recipeProduct is null || (recipeId is not null && recipeProduct.RecipeId != recipeId))
        {
            GraphQlErrorHandler.Custom("Rezeptprodukt wurde nicht gefunden", ErrorCode.NotFound);
            return false;
        }

        dbContext.RecipeProducts.Remove(recipeProduct);
        dbContext.SaveChanges();

        return true;
    }

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