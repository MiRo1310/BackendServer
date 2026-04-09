using BackendServer.Data;
using BackendServer.Models.Entities;
using BackendServer.Models.Entities.Recipes;
using BackendServer.Models.Finance;

namespace BackendServer.Types.Finance;

[QueryType]

public static class DescriptionQuery
{
     [UseFiltering]
     [UseSorting]
     public static IQueryable<Description> Description(FinanceDbContext dbContext)
     {
          return dbContext.Descriptions;
     }
}