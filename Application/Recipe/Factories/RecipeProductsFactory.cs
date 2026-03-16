using BackendServer.Data;
using BackendServer.Models.Entities.Recipes;
using BackendServer.Models.RecipeProduct;

namespace BackendServer.Application.Recipe.Factories;

public static class RecipeProductsFactory
{
    public static void ProcessProducts(AppDbContext dbContext, Models.Entities.Recipes.Recipe recipe,
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
                    Unit = GetUnitName(dbContext, recipeProduct.ActiveUnitId),
                    Description = recipeProduct.Description ?? "",
                    ProductId = recipeProduct.ProductId,
                    GroupPosition = recipeProduct.GroupPosition,
                    ActiveUnitId = recipeProduct.ActiveUnitId,
                    Kcal = ProductFactory.CalculateKcal(dbContext, recipeProduct.ActiveUnitId, recipeProduct.Amount),
                    SortOrder =  recipeProduct.SortOrder
                    
                };

                dbContext.RecipeProducts.Add(product);
                
                ProductFactory.SetActiveUnit(dbContext,recipeProduct.ActiveUnitId);
                continue;
            }

            var productUpdate = dbContext.RecipeProducts.FirstOrDefault(header => header.Id == recipeProduct.Id);
            if (productUpdate is null) continue;

            productUpdate.Amount = recipeProduct.Amount;
            productUpdate.Unit = GetUnitName(dbContext, recipeProduct.ActiveUnitId);
            productUpdate.Description = recipeProduct.Description ?? productUpdate.Description;
            productUpdate.ProductId = recipeProduct.ProductId;
            productUpdate.GroupPosition = recipeProduct.GroupPosition;
            productUpdate.ModifiedAt = DateTime.UtcNow;
            productUpdate.ActiveUnitId = recipeProduct.ActiveUnitId;
            productUpdate.SortOrder = recipeProduct.SortOrder;
           
            productUpdate.Kcal = ProductFactory.CalculateKcal(dbContext, recipeProduct.ActiveUnitId, productUpdate.Amount);
            
            ProductFactory.SetActiveUnit(dbContext,recipeProduct.ActiveUnitId);
        }
    }
    
    private static string GetUnitName(AppDbContext dbContext, Guid unitId)
    {
        return dbContext.ProductUnits.FirstOrDefault(u => u.Id == unitId)?.Unit ?? "Not found";
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