using BackendServer.Models.Finance;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Data;

public class FinanceDbContext : DbContext
{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
    {
    }

    public DbSet<Address> Addresses { get; set; } 
    
    public DbSet<TravelCost> TravelCost { get; set; } 
}