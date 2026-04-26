using BackendServer.Application.Common;
using BackendServer.Application.Enum;
using BackendServer.Data;
using BackendServer.Models.Entities.Recipes;
using BackendServer.Models.Unit;

namespace BackendServer.Application.Recipe.GraphQl;

[MutationType]

public static class UnitMutation
{
    public static Unit CreateUnit(AppDbContext dbContext, UnitCreateDto dto)
    {
        var unit = new Unit()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            CreatedAt = DateTime.UtcNow,
        };

        dbContext.Units.Add(unit);
        dbContext.SaveChanges();
        return unit;
    }

    public static Unit? UpdateUnit(AppDbContext dbContext, UnitUpdateDto dto)
    {
        var unit = dbContext.Units.FirstOrDefault(unit => unit.Id == dto.Id);

        if (unit is null)
        {
            GraphQlErrorHandler.Custom("Einheit wurde nicht gefunden", ErrorCode.NotFound);
            return null;
        }

        unit.Name = dto.Name;
        unit.ModifiedAt = DateTime.UtcNow;

        dbContext.SaveChanges();
        return unit;
    }

    public static bool DeleteUnit(AppDbContext dbContext, Guid id)
    {
        var unit = dbContext.Units.FirstOrDefault(unit => unit.Id == id);

        if (unit is null)
        {
            GraphQlErrorHandler.Custom("Einheit wurde nicht gefunden", ErrorCode.NotFound);
            return false;
        }

        dbContext.Units.Remove(unit);
        dbContext.SaveChanges();

        return true;
    }
}