using Rezepte.Data;
using Rezepte.Models;
using Rezepte.Models.Recipe;
using Rezepte.Models.RecipeDescription;

namespace Rezepte.Types;

public static class RecipeDescriptionHelper
{
    public static void ProcessDescription(AppDbContext dbContext, Recipe recipe,
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
                    Header = textArea.Header ?? ""
                };
                
                dbContext.RecipeDescriptions.Add(text);
                continue;
            }

            var textAreaUpdate = dbContext.RecipeDescriptions.FirstOrDefault(header => header.Id == textArea.Id);
            if (textAreaUpdate is null) continue;

            textAreaUpdate.Text = textArea.Text;
            textAreaUpdate.Header = textArea.Header ?? "";
            textAreaUpdate.Position = textArea.Position;
            textAreaUpdate.ModifiedAt = DateTime.UtcNow;
        }
    }
}