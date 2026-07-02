using BackendServer.Data;
using BackendServer.Models.DTOs.Finance;
using BackendServer.Models.Entities.TravelCost;

namespace BackendServer.Application.Finance.GraphQl;

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
            CreatedAt = DateTime.UtcNow,
            IsValidated = dto.IsValidated ?? false,
            HasInvoice = dto.HasInvoice ?? false,
            
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
        travelCost.Price = dto.Price ?? travelCost.Price;
        travelCost.AddressId = dto.AddressId ?? travelCost.AddressId;
        travelCost.Date = dto.Date ?? travelCost.Date;
        travelCost.Description = dto.Description ?? travelCost.Description;
        travelCost.HasInvoice = dto.HasInvoice ?? travelCost.HasInvoice;
        travelCost.IsValidated = dto.IsValidated ?? travelCost.IsValidated;

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