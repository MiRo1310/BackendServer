using BackendServer.Data;
using BackendServer.Models.Recipe;
using BackendServer.Models.RecipeProduct;

namespace BackendServer.Types;

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
                    Description = recipeProduct.Description ?? "",
                    ProductId = recipeProduct.ProductId,
                    ProductPosition = recipeProduct.ProductPosition,
                    GroupPosition = recipeProduct.GroupPosition,
                    ActiveUnitId = recipeProduct.ActiveUnitId,
                    Kcal = ProductsHelper.CalculateKcal(dbContext, recipeProduct.ActiveUnitId, recipeProduct.Amount??0)
                    
                };

                dbContext.RecipeProducts.Add(product);
                
                ProductsHelper.SetActiveUnit(dbContext,recipeProduct.ActiveUnitId);
                continue;
            }

            var productUpdate = dbContext.RecipeProducts.FirstOrDefault(header => header.Id == recipeProduct.Id);
            if (productUpdate is null) continue;

            productUpdate.Amount = recipeProduct.Amount;
            productUpdate.Unit = recipeProduct.Unit ?? productUpdate.Unit;
            productUpdate.Description = recipeProduct.Description ?? productUpdate.Description;
            productUpdate.ProductId = recipeProduct.ProductId;
            productUpdate.ProductPosition = recipeProduct.ProductPosition;
            productUpdate.GroupPosition = recipeProduct.GroupPosition;
            productUpdate.ModifiedAt = DateTime.UtcNow;
            productUpdate.ActiveUnitId = recipeProduct.ActiveUnitId;
           
            productUpdate.Kcal = ProductsHelper.CalculateKcal(dbContext, recipeProduct.ActiveUnitId, productUpdate.Amount??0);
            
            ProductsHelper.SetActiveUnit(dbContext,recipeProduct.ActiveUnitId);
        }
    }

    public static void RemoveByRecipeId(AppDbContext dbContext, Guid recipeId )
    {
        var products = dbContext.RecipeProducts.Where(p => p.RecipeId == recipeId);
        foreach (var recipeProduct in products)
        {
            dbContext.RecipeProducts.Remove(recipeProduct);
        }

        dbContext.SaveChanges();
    }
}