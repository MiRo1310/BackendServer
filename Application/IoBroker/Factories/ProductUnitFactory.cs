using BackendServer.Data;
using BackendServer.Models.DTOs.IoBroker;
using BackendServer.Models.Entities.IoBroker;

namespace BackendServer.Application.IoBroker.Factories;

public static class ProductUnitFactory
{
    public static void ProcessUnit(AppDbContext dbContext, ICollection<ProductUnitCreateOrUpdateDto?> productUnits,
        Guid productId, ProductUnit? defaultUnit)
    {
        
        foreach (var dtoProductUnit in productUnits)
        {
            
            var defaultAmount = defaultUnit?.Amount??1;
            
            if (dtoProductUnit is null) continue;

            UnitFactory.EnsureExists(dbContext, dtoProductUnit.UnitId);

            if (dtoProductUnit.Id is null)
            {
                var unitExist = dbContext.ProductUnits.Any(u => u.UnitId == dtoProductUnit.UnitId && u.ProductId == productId);
                if (unitExist)
                {
                    continue;
                }
                
                var newUnit = new ProductUnit
                {
                    Amount = dtoProductUnit.Amount,
                    CreatedAt = DateTime.UtcNow,
                    Id = Guid.NewGuid(),
                    ProductId = productId,
                    UnitId = dtoProductUnit.UnitId,
                    Faktor = Math.Round(dtoProductUnit.Amount / defaultAmount,4)
                    
                };
                dbContext.ProductUnits.Add(newUnit);
                continue;
            }

            var unit = dbContext.ProductUnits.FirstOrDefault(unit => unit.Id == dtoProductUnit.Id);
            if (unit is null) continue;

            unit.Amount = dtoProductUnit.Amount;
            unit.ModifiedAt = DateTime.UtcNow;
            unit.UnitId = dtoProductUnit.UnitId;
            unit.Faktor = Math.Round(dtoProductUnit.Amount / defaultAmount, 4);
        }
    }
}