
using BackendServer.Data;
using BackendServer.Models.ProductUnit;


namespace BackendServer.Types;

[QueryType]
public static class ProductUnitQuery
{
    public static IQueryable<ProductUnit> GetProductUnits(AppDbContext dbContext)
    {
        return dbContext.ProductUnits;
    }

    public static ProductUnit? GetProductUnit(AppDbContext dbContext, Guid id)
    {
        return dbContext.ProductUnits
            .FirstOrDefault(unit => unit.Id == id);
    }

    public static ProductUnit? GetProductUnitByProductId(AppDbContext dbContext, Guid productId)
    {
        return dbContext.ProductUnits
            .FirstOrDefault(unit => unit.ProductId == productId);
    }
}