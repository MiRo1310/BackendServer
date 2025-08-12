using Microsoft.EntityFrameworkCore;
using Rezepte.Data;
using Rezepte.Models;

namespace Rezepte.Types;

[QueryType]
public static class ProductUnitQuery
{
    public static IQueryable<ProductUnit> GetProductUnits(AppDbContext dbContext)
    {
        return dbContext.ProductUnits.Include(unit => unit.RecipeProduct );
    }

    public static ProductUnit? GetProductUnit(AppDbContext dbContext, Guid id)
    {
        return dbContext.ProductUnits
            .Include(unit => unit.RecipeProduct )
            .FirstOrDefault(unit => unit.Id == id);
    }

    public static ProductUnit? GetProductUnitByProductId(AppDbContext dbContext, Guid productId)
    {
        return dbContext.ProductUnits
            .Include(unit => unit.RecipeProduct )
            .FirstOrDefault(unit => unit.ProductId == productId);
    }
}