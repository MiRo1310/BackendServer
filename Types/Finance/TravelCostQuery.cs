using BackendServer.Data;
using BackendServer.Models.Finance;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Types.Finance;

[QueryType]
public static class TravelCostQuery
{
    
    [UseSorting]
    
    public static IQueryable<TravelCost> TravelCost(FinanceDbContext dbContext)
    {
        return  dbContext.TravelCost.Include(cost => cost.Address );
    }
}