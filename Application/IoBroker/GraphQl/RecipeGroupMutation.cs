using BackendServer.Data;
using BackendServer.Models.DTOs.IoBroker;

namespace BackendServer.Application.IoBroker.GraphQl;

[MutationType]
public static class RecipeGroupMutation
{
    [GraphQLDeprecated(deprecationReason:"Use recipeMutation")]
    public static bool RemoveProductGroup(AppDbContext dbContext, RecipeGroupRemoveDto dto)
    {
       return RecipeMutationHelper.RemoveProductGroup(dbContext, dto);
    }
}