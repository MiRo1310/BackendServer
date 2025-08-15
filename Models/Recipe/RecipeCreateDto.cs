namespace Rezepte.Models;

public class RecipeCreateDto
{
    public required string Name { get; set; }

    public required int Portions { get; set; }

    public ICollection<RecipeHeaderCreateOrUpdateDto?>? RecipeHeaders { get; set; }

    public ICollection<RecipeDescriptionCreateOrUpdateDto?>? RecipeTextAreas { get; set; }

    public ICollection<RecipeHeaderProductCreateOrUpdateDto?>? RecipeHeaderProducts { get; set; }

    public ICollection<RecipeProductsCreateDto?>? RecipeProducts { get; set; }
}