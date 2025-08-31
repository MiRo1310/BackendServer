using BackendServer.Data;
namespace BackendServer.Types;

[MutationType]

public static class RecipeDescriptionMutation
{
 public static bool RemoveTextArea(AppDbContext dbContext, Guid id)
 {
     var textarea = dbContext.RecipeDescriptions.FirstOrDefault(textarea => textarea.Id == id);

     if (textarea is null)
     {
         return false;
     }

     dbContext.RecipeDescriptions.Remove(textarea);
     dbContext.SaveChanges();
     
     Descriptions.ReSetPositions(dbContext, textarea.RecipeId);

     return true;
 }
}