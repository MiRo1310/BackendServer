using Rezepte.Data;
using Rezepte.Models;

namespace Rezepte.Types;

[MutationType]

public static class RecipeHeaderMutation
{
    public static RecipeHeader CreateRecipeHeaders(AppDbContext dbContext, RecipeHeaderCreateDto dto)
    {
        var header = new RecipeHeader()
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Position = dto.Position,
            RecipeId = dto.RecipeId,
            Text = dto.Text
        };

        dbContext.RecipeHeaders.Add(header);
        dbContext.SaveChanges();

        return header;
    }
}