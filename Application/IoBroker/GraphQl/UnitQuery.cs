using BackendServer.Data;
using BackendServer.Models.Entities.IoBroker;

namespace BackendServer.Application.IoBroker.GraphQl;

[QueryType]
public static class UnitQuery
{
    [UseSorting]
    [UseFiltering]
    public static IQueryable<Unit> GetUnits(AppDbContext dbContext)
    {
        return dbContext.Units;
    }

    public static Unit? GetUnit(AppDbContext dbContext, Guid id)
    {
        return dbContext.Units.FirstOrDefault(unit => unit.Id == id);
    }
    
}