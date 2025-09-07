using BackendServer.Data;

namespace BackendServer.Types;

public static class ProductsHelper
{
    public static void SetActiveUnit(AppDbContext dbContext, Guid id)
    {
        foreach (var dbContextProductUnit in dbContext.ProductUnits)
        {
            if (dbContextProductUnit.Id == id)
            {
                dbContextProductUnit.Active = true;
                continue;
            }

            dbContextProductUnit.Active = false;
        }
    }

    public static int CalculateKcal(AppDbContext dbContext, Guid id, decimal amount)
    {
        var activeUnit = dbContext.ProductUnits.FirstOrDefault(unit => unit.Id == id);

        if (activeUnit is null)
        {
            return 0;
        }

        var product = dbContext.Products.FirstOrDefault(product => product.Id == activeUnit.ProductId);
        if (product is null)
        {
            return 0;
        }
        
        if (activeUnit.IsDefault)
        {
            return (int)Math.Round(amount / (activeUnit.Amount ??0 ) * (product.Kcal ?? 0));
        }

        return (int)Math.Round(amount * activeUnit.Faktor  * (product.Kcal ??0));
    }
}