using BackendServer.Application.Common;
using BackendServer.Application.Enum;
using BackendServer.Application.IoBroker.Factories;
using BackendServer.Data;
using BackendServer.Models.Entities.IoBroker;
using BackendServer.Models.DTOs.IoBroker;
using BackendServer.Models.DTOs.IoBroker.Unit;

namespace BackendServer.Application.IoBroker.GraphQl;

[MutationType]

public static class UnitMutation
{
    public static Unit? CreateUnit(AppDbContext dbContext, UnitCreateDto dto)
    {
        if (UnitFactory.NameExists(dbContext, dto.Name))
        {
            GraphQlErrorHandler.Custom("Einheit existiert bereits", ErrorCode.Exist);
            return null;
        }

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

        if (UnitFactory.NameExists(dbContext, dto.Name, dto.Id))
        {
            GraphQlErrorHandler.Custom("Einheit existiert bereits", ErrorCode.Exist);
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

        if (UnitFactory.IsInUse(dbContext, id))
        {
            GraphQlErrorHandler.Custom("Einheit wird schon genutzt, und kann daher nicht gelöscht werden", ErrorCode.InUse);
            return false;
        }

        dbContext.Units.Remove(unit);
        dbContext.SaveChanges();

        return true;
    }
}