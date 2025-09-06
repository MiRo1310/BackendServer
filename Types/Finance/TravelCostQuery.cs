using BackendServer.Data;
using BackendServer.Models.Finance;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Types.Finance;

[QueryType]
public static class TravelCostQuery
{
    
    [UseSorting]
    [UseFiltering]
    public static IQueryable<TravelCost> TravelCost(FinanceDbContext dbContext)
    {
        return  dbContext.TravelCost
            .Include(c => c.Address );
    }
    
   public static TravelCostSortPerMonthDto TravelCostSortPerMonth(FinanceDbContext dbContext, int year)
    {

        var travelCost = dbContext.TravelCost
            .Include(t=> t.Address)
            .Where(t=> t.Date != null && t.Date.Value.Year == year);
        
        return  new TravelCostSortPerMonthDto
        {
            M1 = GetTravelCostByMonth(travelCost, 1),
            M2 = GetTravelCostByMonth(travelCost,2),
            M3 = GetTravelCostByMonth(travelCost,3),
            M4 = GetTravelCostByMonth(travelCost,4),
            M5 = GetTravelCostByMonth(travelCost,5),
            M6 = GetTravelCostByMonth(travelCost,6),
            M7 = GetTravelCostByMonth(travelCost,7),
            M8 = GetTravelCostByMonth(travelCost,8),
            M9 = GetTravelCostByMonth(travelCost,9),
            M10 =GetTravelCostByMonth(travelCost,10),
            M11 = GetTravelCostByMonth(travelCost,11),
            M12 = GetTravelCostByMonth(travelCost,12)
        };
    }
   
    private static IQueryable<TravelCost> GetTravelCostByMonth(IQueryable<TravelCost> costs,  int month)
    {
        return costs.Where(c => c.Date != null && c.Date.Value.Month == month).OrderBy(c => c.Date);
    }
}