using Rezepte.Data;
using Rezepte.Models;

namespace Rezepte.Types;

public static class ProductUnitHelper
{
    public static void ProcessUnit(AppDbContext dbContext, ICollection<ProductUnitCreateOrUpdateDto?> productUnits,
        Guid productId)
    {
        foreach (var dtoProductUnit in productUnits)
        {
            if (dtoProductUnit is null) continue;

            if (dtoProductUnit.Id is null)
            {
                var newUnit = new ProductUnit
                {
                    Amount = dtoProductUnit.Amount,
                    CreatedAt = DateTime.UtcNow,
                    DefaultUnit = dtoProductUnit.DefaultUnit,
                    Id = Guid.NewGuid(),
                    ProductId = productId,
                    Unit = dtoProductUnit.Unit
                };
                dbContext.ProductUnits.Add(newUnit);
                continue;
            }

            var unit = dbContext.ProductUnits.FirstOrDefault(unit => unit.Id == dtoProductUnit.Id);
            if (unit is null) continue;

            unit.Amount = dtoProductUnit.Amount;
            unit.ModifiedAt = DateTime.UtcNow;
            unit.DefaultUnit = dtoProductUnit.DefaultUnit;
            unit.Unit = dtoProductUnit.Unit;
        }
    }
}