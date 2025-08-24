using BackendServer.Data;
using BackendServer.Models;
using BackendServer.Models.ProductUnit;

namespace BackendServer.Types;

public static class ProductUnitHelper
{
    public static void ProcessUnit(AppDbContext dbContext, ICollection<ProductUnitCreateOrUpdateDto?> productUnits,
        Guid productId, ProductUnit? defaultUnit)
    {
        
        foreach (var dtoProductUnit in productUnits)
        {
            
            var defaultAmount = defaultUnit?.Amount??1;
            
            if (dtoProductUnit is null) continue;

            if (dtoProductUnit.Id is null)
            {
                var newUnit = new ProductUnit
                {
                    Amount = dtoProductUnit.Amount,
                    CreatedAt = DateTime.UtcNow,
                    Id = Guid.NewGuid(),
                    ProductId = productId,
                    Unit = dtoProductUnit.Unit,
                    Faktor = Math.Round(dtoProductUnit.Amount / defaultAmount,4)
                    
                };
                dbContext.ProductUnits.Add(newUnit);
                continue;
            }

            var unit = dbContext.ProductUnits.FirstOrDefault(unit => unit.Id == dtoProductUnit.Id);
            if (unit is null) continue;

            unit.Amount = dtoProductUnit.Amount;
            unit.ModifiedAt = DateTime.UtcNow;
            unit.Unit = dtoProductUnit.Unit;
            unit.Faktor = Math.Round(dtoProductUnit.Amount / defaultAmount, 4);
        }
    }
}