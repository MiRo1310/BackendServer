using BackendServer.Application.Common;
using BackendServer.Application.Enum;
using BackendServer.Data;

namespace BackendServer.Application.IoBroker.GraphQl;

[MutationType]

public static class RecipeProductsMutation
{
     [GraphQLDeprecated(deprecationReason:"Use recipeMutation")]
     public static bool RemoveRecipeProduct(AppDbContext dbContext, Guid id)
     {
          return RecipeMutationHelper.RemoveRecipeProduct(dbContext, id);
     }
}