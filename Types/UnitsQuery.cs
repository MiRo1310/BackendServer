using Rezepte.Data;
using Rezepte.Models;

namespace Rezepte.Types;

[QueryType]
public static class UnitsQuery
{
    public static IQueryable<Unit> GetUnits(AppDbContext dbContext)
    {
        return dbContext.Units;
    }

    public static Unit? GetUnit(AppDbContext dbContext, Guid id)
    {
        return dbContext.Units.FirstOrDefault(unit => unit.Id == id);
    }
    
}