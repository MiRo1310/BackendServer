using BackendServer.Application.Common;
using BackendServer.Application.Enum;
using BackendServer.Application.Recipe.Factories;
using BackendServer.Data;

namespace BackendServer.Application.Recipe.GraphQl;

[MutationType]

public static class RecipeDescriptionMutation
{
 public static bool RemoveTextArea(AppDbContext dbContext, Guid id)
 {
     var textarea = dbContext.RecipeDescriptions.FirstOrDefault(textarea => textarea.Id == id);

     if (textarea is null)
     {
         GraphQlErrorHandler.Custom("Beschreibung wurde nicht gefunden", ErrorCode.NotFound);
         return false;
     }

     dbContext.RecipeDescriptions.Remove(textarea);
     dbContext.SaveChanges();
     
     DescriptionFactory.ResetPositions(dbContext, textarea.RecipeId);

     return true;
 }
}