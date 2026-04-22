using BackendServer.Application.Enum;
using BackendServer.Data;
using BackendServer.Models.Entities.Recipes;

namespace BackendServer.Application.Recipe.GraphQl;

[QueryType]
public static class UnitQuery
{
    [UseSorting(Scope = nameof(GraphQlScope.MySql))]
    [UseFiltering(Scope = nameof(GraphQlScope.MySql))]
    public static IQueryable<Unit> GetUnits(AppDbContext dbContext)
    {
        return dbContext.Units;
    }

    public static Unit? GetUnit(AppDbContext dbContext, Guid id)
    {
        return dbContext.Units.FirstOrDefault(unit => unit.Id == id);
    }
    
}