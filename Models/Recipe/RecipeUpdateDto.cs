using BackendServer.Models.RecipeProduct;

namespace BackendServer.Models.Recipe;

public class RecipeUpdateDto
{
    public required Guid Id { get; set; }

    public string? Name { get; set; }

    public int? Portions { get; set; } = 0;
   
    public Guid ActiveUnit { get; set; }
    
    public ICollection<RecipeDescriptionCreateOrUpdateDto?>? RecipeDescriptions { get; set; }

    public ICollection<RecipeHeaderProductCreateOrUpdateDto?>? RecipeHeaderProducts { get; set; }

    public ICollection<RecipeProductsCreateDto?>? RecipeProducts { get; set; }
}