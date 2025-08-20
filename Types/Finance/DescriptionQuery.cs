using BackendServer.Data;
using BackendServer.Models.Finance;

namespace BackendServer.Types.Finance;

[QueryType]

public static class DescriptionQuery
{
     public static IQueryable<Description> Description(FinanceDbContext dbContext)
     {
          return dbContext.Descriptions;
     }
}