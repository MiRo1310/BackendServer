
namespace BackendServer.Models.DTOs.IoBroker;

public class RecipeCreateDto
{
    public required string Name { get; set; }

    public int Portions { get; set; }
    
    public Guid? RecipeCategoryId { get; set; }
    
    public int? PreparationTimeMin { get; set; } = null;
    
    public int? TotalTimeMin { get; set; } = null;

    public ICollection<RecipeDescriptionCreateOrUpdateDto?>? RecipeDescriptions { get; set; }

    public ICollection<RecipeHeaderProductCreateOrUpdateDto?>? RecipeHeaderProducts { get; set; }

    public ICollection<RecipeProductsCreateDto?>? RecipeProducts { get; set; }
}