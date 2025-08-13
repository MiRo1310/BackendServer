using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Rezepte.Data;
using Rezepte.Models;

namespace Rezepte.Types;

[QueryType]

public static class RecipeImageQuery
{
    public static IQueryable<RecipeImage>? GetRecipeImages(AppDbContext dbContext)
    {
        return dbContext.RecipeImages
            .Include(image=> image.Recipe);
    }
}