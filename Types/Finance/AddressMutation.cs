using BackendServer.Data;
using BackendServer.Models.Finance;

namespace BackendServer.Types.Finance;

[MutationType]

public static class AddressMutation
{
    public static Address CreateAddress(FinanceDbContext dbContext, AddressCreateDto dto)
    {
        var address= new Address()
        {
            Id = Guid.NewGuid(),
            City = dto.City,
            CreatedAt = DateTime.UtcNow,
            Name = dto.Name,
            Street = dto.Street
        };
        dbContext.Addresses.Add(address);
        dbContext.SaveChanges();
        return address;
    }

    public static Address? UpdateAddress(FinanceDbContext dbContext, AddressUpdateDto dto)
    {
        var address = dbContext.Addresses.FirstOrDefault(address => address.Id == dto.Id);

        if (address is null)
        {
            return null;
        }

        address.City = dto.City;
        address.Name = dto.Name;
        address.Street = dto.Street;
        address.ModifiedAt= DateTime.UtcNow;

        dbContext.SaveChanges();
        return address;
    }

    public static bool RemoveAddress(FinanceDbContext dbContext, Guid id)
    {
        var address = dbContext.Addresses.FirstOrDefault(address => address.Id == id);
        if (address is null)
        {
            return false;
        }

        dbContext.Addresses.Remove(address);
        dbContext.SaveChanges();

        return true;
    }
}