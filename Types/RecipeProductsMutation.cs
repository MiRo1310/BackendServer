using Rezepte.Data;

namespace Rezepte.Types;

[MutationType]

public static class RecipeProductsMutation
{
     public static bool RemoveRecipeProduct(AppDbContext dbContext, Guid id)
     {
          var recipeProduct = dbContext.RecipeProducts.FirstOrDefault(product => product.Id == id);
          
          if(recipeProduct is null)
          {
               return false;
          }

          dbContext.RecipeProducts.Remove(recipeProduct);
          dbContext.SaveChanges();

          return true;
     }
}