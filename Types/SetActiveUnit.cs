using BackendServer.Data;

namespace BackendServer.Types;

public static class UnitsHelper
{
    public static void SetActive(AppDbContext dbContext, Guid id)
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
}