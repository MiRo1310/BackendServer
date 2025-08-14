using Rezepte.Data;
using Rezepte.Models;

namespace Rezepte.Types;

public static class RecipeHeaderHelper
{
    public static void ProcessHeaders(AppDbContext dbContext, Recipe recipe,
        ICollection<RecipeHeaderCreateOrUpdateDto?> headers)
    {
        foreach (var recipeHeader in headers)
        {
            if (recipeHeader is null) continue;

            if (recipeHeader.Id is null)
            {
                var header = new RecipeHeader
                {
                    CreatedAt = DateTime.UtcNow,
                    Id = Guid.NewGuid(),
                    Position = recipeHeader.Position,
                    RecipeId = recipe.Id,
                    Text = recipeHeader.Text
                };
                recipe.Headers.Add(header);
                continue;
            }

            var headerUpdate = dbContext.RecipeHeaders.FirstOrDefault(header => header.Id == recipeHeader.Id);
            if (headerUpdate is null) continue;

            headerUpdate.Position = recipeHeader.Position;
            headerUpdate.Text = recipeHeader.Text;
            headerUpdate.ModifiedAt = DateTime.UtcNow;
        }
    }
}