using BackendServer.Data;
using BackendServer.Models.Entities;
using BackendServer.Models.Entities.Recipes;
using BackendServer.Models.Entities.TravelCost;
using BackendServer.Models.Finance;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Types.Finance;

[QueryType]
public static class AddressQuery
{
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Address> Addresses(FinanceDbContext dbContext)
    {
        return dbContext.Addresses.Include(address=>address.TravelCost);
    }
    
    public static Address? Address(FinanceDbContext dbContext, Guid id)
    {
        return dbContext.Addresses.Include(address=>address.TravelCost).FirstOrDefault(address=> address.Id == id);
    }  
    
    
}