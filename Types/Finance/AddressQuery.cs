using BackendServer.Data;
using BackendServer.Models.Finance;

namespace BackendServer.Types.Finance;

[QueryType]
public static class AddressQuery
{
    public static IQueryable<Address> Addresses(FinanceDbContext dbContext)
    {
        return dbContext.Addresses;
    }
    
    public static Address? Address(FinanceDbContext dbContext, Guid id)
    {
        return dbContext.Addresses.FirstOrDefault(address=> address.Id == id);
    }  
    
    
}