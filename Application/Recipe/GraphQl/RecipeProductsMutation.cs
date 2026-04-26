using BackendServer.Application.Common;
using BackendServer.Application.Enum;
using BackendServer.Data;

namespace BackendServer.Application.Recipe.GraphQl;

[MutationType]

public static class RecipeProductsMutation
{
     public static bool RemoveRecipeProduct(AppDbContext dbContext, Guid id)
     {
          var recipeProduct = dbContext.RecipeProducts.FirstOrDefault(product => product.Id == id);
          
          if(recipeProduct is null)
          {
               GraphQlErrorHandler.Custom("Rezeptprodukt wurde nicht gefunden", ErrorCode.NotFound);
               return false;
          }

          dbContext.RecipeProducts.Remove(recipeProduct);
          dbContext.SaveChanges();

          return true;
     }
}