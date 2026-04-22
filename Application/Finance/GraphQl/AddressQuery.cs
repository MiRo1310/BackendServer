using BackendServer.Application.Enum;
using BackendServer.Data;
using BackendServer.Models.Entities.TravelCost;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Application.Finance.GraphQl;

[QueryType]
public static class AddressQuery
{
    [UseFiltering(Scope = nameof(GraphQlScope.MySql))]
    [UseSorting(Scope = nameof(GraphQlScope.MySql))]
    public static IQueryable<Address> Addresses(FinanceDbContext dbContext)
    {
        return dbContext.Addresses.Include(address=>address.TravelCost);
    }
    
    public static Address? Address(FinanceDbContext dbContext, Guid id)
    {
        return dbContext.Addresses.Include(address=>address.TravelCost).FirstOrDefault(address=> address.Id == id);
    }  
    
    
}