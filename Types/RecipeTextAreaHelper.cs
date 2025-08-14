using Rezepte.Data;
using Rezepte.Models;

namespace Rezepte.Types;

public static class RecipeTextAreaHelper
{
    public static void ProcessProducts(AppDbContext dbContext, Recipe recipe,
        ICollection<RecipeTextAreaCreateDto?> textAreas)
    {
        foreach (var textArea in textAreas)
        {
            if (textArea is null) continue;
            if (textArea.Id is null)
            {
                var text = new RecipeTextArea
                {
                    CreatedAt = DateTime.UtcNow,
                    Id = Guid.NewGuid(),
                    RecipeId = recipe.Id,
                    Position = textArea.Position,
                    Text = textArea.Text
                };
                
                recipe.RecipeTextAreas.Add(text);
                continue;
            }

            var textAreaUpdate = dbContext.RecipeTextAreas.FirstOrDefault(header => header.Id == textArea.Id);
            if (textAreaUpdate is null) continue;

            textAreaUpdate.Text = textArea.Text;
            textAreaUpdate.Position = textArea.Position;
            textAreaUpdate.ModifiedAt = DateTime.UtcNow;
        }
    }
}