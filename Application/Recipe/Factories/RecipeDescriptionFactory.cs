using BackendServer.Data;
using BackendServer.Models.Entities.Recipes;
using BackendServer.Models.RecipeDescription;

namespace BackendServer.Application.Recipe.Factories;

public static class RecipeDescriptionFactory
{
    public static void ProcessDescription(AppDbContext dbContext, Models.Entities.Recipes.Recipe recipe,
        ICollection<RecipeDescriptionCreateOrUpdateDto?> textAreas)
    {
        foreach (var textArea in textAreas)
        {
            if (textArea is null) continue;
            if (textArea.Id is null)
            {
                var text = new RecipeDescription
                {
                    CreatedAt = DateTime.UtcNow,
                    Id = Guid.NewGuid(),
                    RecipeId = recipe.Id,
                    Position = textArea.Position,
                    Text = textArea.Text,
                    Header = textArea.Header
                };
                
                dbContext.RecipeDescriptions.Add(text);
                continue;
            }

            var textAreaUpdate = dbContext.RecipeDescriptions.FirstOrDefault(header => header.Id == textArea.Id);
            if (textAreaUpdate is null) continue;

            textAreaUpdate.Text = textArea.Text;
            textAreaUpdate.Header = textArea.Header;
            textAreaUpdate.Position = textArea.Position;
            textAreaUpdate.ModifiedAt = DateTime.UtcNow;
        }
    }

    public static void RemoveDescription(AppDbContext dbContext, Guid recipeId)
    {
        var recipeDescriptions = dbContext.RecipeDescriptions.Where(d => d.RecipeId == recipeId);

        if (!recipeDescriptions.Any()) return;
        
        dbContext.RecipeDescriptions.RemoveRange(recipeDescriptions);
        dbContext.SaveChanges();
    }
}