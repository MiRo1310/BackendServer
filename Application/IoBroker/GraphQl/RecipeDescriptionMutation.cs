using BackendServer.Application.Common;
using BackendServer.Application.Enum;
using BackendServer.Application.IoBroker.Factories;
using BackendServer.Data;

namespace BackendServer.Application.IoBroker.GraphQl;

[MutationType]


public static class RecipeDescriptionMutation
{
  
    [GraphQLDeprecated(deprecationReason:"Use recipeMutation")]
 public static bool RemoveTextArea(AppDbContext dbContext, Guid id)
 {
     return RecipeMutationHelper.RemoveTextarea(dbContext, id);
 }
}