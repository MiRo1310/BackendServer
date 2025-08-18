using BackendServer.Models.Finance;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Data;

public class FinanceDbContext : DbContext
{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
    {
    }

    public DbSet<Addresses> Addresses { get; set; } 
}