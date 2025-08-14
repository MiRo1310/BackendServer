using Rezepte.Data;

namespace Rezepte.Types;

[MutationType]

public static class ProductUnitMutation
{
     public static bool RemoveProductUnit(AppDbContext dbContext, Guid id)
     {
          var unit = dbContext.ProductUnits.FirstOrDefault(unit => unit.Id == id);

          if (unit is null)
          {
               return false;
          }

          dbContext.ProductUnits.Remove(unit);
          dbContext.SaveChanges();
          return true;
     }
}