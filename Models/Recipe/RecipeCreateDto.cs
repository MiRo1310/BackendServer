namespace BackendServer.Models;

public class RecipeCreateDto
{
    public required string Name { get; set; }

    public int Portions { get; set; }

    public ICollection<RecipeDescriptionCreateOrUpdateDto?>? RecipeDescriptions { get; set; }

    public ICollection<RecipeHeaderProductCreateOrUpdateDto?>? RecipeHeaderProducts { get; set; }

    public ICollection<RecipeProductsCreateDto?>? RecipeProducts { get; set; }
}