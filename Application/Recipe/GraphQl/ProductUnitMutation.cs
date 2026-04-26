using BackendServer.Application.Common;
using BackendServer.Application.Enum;
using BackendServer.Data;

namespace BackendServer.Application.Recipe.GraphQl;

[MutationType]

public static class ProductUnitMutation
{
     public static bool RemoveProductUnit(AppDbContext dbContext, Guid id)
     {
          var unit = dbContext.ProductUnits.FirstOrDefault(unit => unit.Id == id);

          if (unit is null)
          {
               GraphQlErrorHandler.Custom("Einheit wurde nicht gefunden", ErrorCode.NotFound);
               return false;
          }

          dbContext.ProductUnits.Remove(unit);
          dbContext.SaveChanges();
          return true;
     }
}