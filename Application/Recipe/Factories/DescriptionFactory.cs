using BackendServer.Data;

namespace BackendServer.Application.Recipe.Factories;

public static class DescriptionFactory
{
    public static void ResetPositions(AppDbContext dbContext, Guid recipeId)
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