using BackendServer.Data;
using BackendServer.Models.Finance;

namespace BackendServer.Types.Finance;

[MutationType]
public static class TravelCostMutation
{
    public static TravelCost CreateTravelCost(FinanceDbContext dbContext, TravelCostCreateDto dto)
    {
        var travelCost = new TravelCost()
        {
            Id = Guid.NewGuid(),
            AddressId = dto.AddressId,
            Date = dto.Date,
            Description = dto.Description,
            Price = dto.Price,
            CreatedAt = DateTime.UtcNow
        };
        dbContext.TravelCost.Add(travelCost);
        dbContext.SaveChanges();
        return travelCost;
    }
    
    
    public static TravelCost? UpdateTravelCost(FinanceDbContext dbContext, TravelCostUpdateDto dto)
    {
        var travelCost = dbContext.TravelCost.FirstOrDefault(item => item.Id == dto.Id);

        if (travelCost is null)
        {
            return null;
        }
        
        travelCost.ModifiedAt = DateTime.UtcNow;
        travelCost.Price = dto.Price;
        travelCost.AddressId = dto.AddressId;
        travelCost.Date = dto.Date;
        travelCost.Description = dto.Description;

        dbContext.SaveChanges();
        return travelCost;
    }

    public static bool RemoveTravelCost(FinanceDbContext dbContext, Guid id)
    {
        var travelCost = dbContext.TravelCost.FirstOrDefault(cost => cost.Id == id);

        if (travelCost is null)
        {
            return false;
        }

        dbContext.TravelCost.Remove(travelCost);
        dbContext.SaveChanges();

        return true;
    }
}