using BackendServer.Data;
using BackendServer.Models.Entities.Recipes;

namespace BackendServer.Application.Finance.GraphQl;

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