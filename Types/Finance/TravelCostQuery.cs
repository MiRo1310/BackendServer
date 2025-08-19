using BackendServer.Data;
using BackendServer.Models.Finance;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Types.Finance;

[QueryType]
public static class TravelCostQuery
{
    
    [UseSorting]
    
    public static CalculatedTravelCost TravelCost(FinanceDbContext dbContext)
    {
        var summary = dbContext.TravelCost.Include(cost => cost.Address ).ToList();
        
        var totalPrice = summary.Sum(item => item.Price);

        return new CalculatedTravelCost()
        {
            TravelCost = summary,
            Total = totalPrice ?? 0
        };
    }
    
    
}