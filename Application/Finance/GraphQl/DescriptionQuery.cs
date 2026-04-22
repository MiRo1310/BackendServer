using BackendServer.Application.Enum;
using BackendServer.Data;
using BackendServer.Models.Entities.Recipes;

namespace BackendServer.Application.Finance.GraphQl;

[QueryType]

public static class DescriptionQuery
{
     [UseFiltering(Scope = nameof(GraphQlScope.MySql))]
     [UseSorting(Scope = nameof(GraphQlScope.MySql))]
     public static IQueryable<Description> Description(FinanceDbContext dbContext)
     {
          return dbContext.Descriptions;
     }
}