namespace Rezepte.Models;

public class RecipeUpdateDto
{
    public required Guid Id { get; set; }

    public string? Name { get; set; }

    public int? Portions { get; set; }

    public ICollection<RecipeDescriptionCreateOrUpdateDto?>? RecipeTextAreas { get; set; }

    public ICollection<RecipeHeaderProductCreateOrUpdateDto?>? RecipeHeaderProducts { get; set; }

    public ICollection<RecipeProductsCreateDto?>? RecipeProducts { get; set; }
}