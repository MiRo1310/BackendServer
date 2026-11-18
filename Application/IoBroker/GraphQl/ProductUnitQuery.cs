using BackendServer.Data;
using BackendServer.Models.Entities.IoBroker;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Application.IoBroker.GraphQl;

[QueryType]
public static class ProductUnitQuery
{
    public static IQueryable<ProductUnit> GetProductUnits(AppDbContext dbContext)
    {
        return dbContext.ProductUnits.Include(unit => unit.Unit);
    }

    public static ProductUnit? GetProductUnit(AppDbContext dbContext, Guid id)
    {
        return dbContext.ProductUnits
            .Include(unit => unit.Unit)
            .FirstOrDefault(unit => unit.Id == id);
    }

    public static ProductUnit? GetProductUnitByProductId(AppDbContext dbContext, Guid productId)
    {
        return dbContext.ProductUnits
            .Include(unit => unit.Unit)
            .FirstOrDefault(unit => unit.ProductId == productId);
    }
}