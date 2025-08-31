using BackendServer.Data;

namespace BackendServer.Types;

public static class Descriptions
{
    public static void ReSetPositions(AppDbContext dbContext, Guid recipeId)
    {
        var descriptions = dbContext.RecipeDescriptions
            .Where(description => description.RecipeId == recipeId)
            .OrderBy(d=> d.Position);
      
        var index = 0;
        foreach (var recipeDescription in descriptions)
        {
            index++;
            recipeDescription.Position = index;
        }

        dbContext.SaveChanges();
    }
}