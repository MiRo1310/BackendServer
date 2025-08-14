using Rezepte.Data;

namespace Rezepte.Types;

[MutationType]

public class RecipeTextareaMutation
{
 public static bool RemoveTextArea(AppDbContext dbContext, Guid id)
 {
     var textarea = dbContext.RecipeTextAreas.FirstOrDefault(textarea => textarea.Id == id);

     if (textarea is null)
     {
         return false;
     }

     dbContext.RecipeTextAreas.Remove(textarea);
     dbContext.SaveChanges();

     return true;
 }
}