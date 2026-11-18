using BackendServer.Application.Common;
using BackendServer.Application.Enum;
using BackendServer.Data;

namespace BackendServer.Application.IoBroker.Factories;

public static class UnitFactory
{
    /// <summary>
    /// Throws a GraphQL NotFound error if no unit with the given id exists.
    /// </summary>
    public static void EnsureExists(AppDbContext dbContext, Guid unitId)
    {
        if (!dbContext.Units.Any(unit => unit.Id == unitId))
        {
            GraphQlErrorHandler.Custom("Einheit wurde nicht gefunden", ErrorCode.NotFound);
        }
    }

    public static bool IsInUse(AppDbContext dbContext, Guid unitId)
    {
        return dbContext.Products.Any(product => product.UnitId == unitId)
               || dbContext.ProductUnits.Any(productUnit => productUnit.UnitId == unitId);
    }

    public static bool NameExists(AppDbContext dbContext, string name, Guid? exceptId = null)
    {
        return dbContext.Units.Any(unit => unit.Name == name && unit.Id != exceptId);
    }
}
