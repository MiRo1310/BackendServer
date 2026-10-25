
namespace BackendServer.Models.DTOs.IoBroker;

public class RecipeUpdateDto
{
    public required Guid Id { get; set; }
    
    public Guid? RecipeCategoryId { get; set; }

    public string? Name { get; set; }

    public int? Portions { get; set; } = 1;
    
    public int? PreparationTimeMin { get; set; } = null;
    
    public int? TotalTimeMin { get; set; } = null;
    
    public ICollection<RecipeDescriptionCreateOrUpdateDto?>? RecipeDescriptions { get; set; }

    public ICollection<RecipeHeaderProductCreateOrUpdateDto?>? RecipeHeaderProducts { get; set; }

    public ICollection<RecipeProductsCreateDto?>? RecipeProducts { get; set; }
}