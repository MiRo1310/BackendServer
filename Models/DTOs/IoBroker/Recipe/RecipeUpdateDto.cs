
namespace BackendServer.Models.DTOs.IoBroker.Recipe;

public class RecipeUpdateDto
{
    public required Guid Id { get; set; }
    
    public Guid? RecipeCategoryId { get; set; }

    public string? Name { get; set; }

    public int? Portions { get; set; } = 1;
    
    public int? PreparationTimeMin { get; set; } = null;
    
    public int? TotalTimeMin { get; set; } = null;
    
    public bool? IsFavorite { get; set; }
    
    public ICollection<RecipeDescriptionCreateOrUpdateDto?>? RecipeDescriptions { get; set; }

    public ICollection<RecipeHeaderProductCreateOrUpdateDto?>? RecipeHeaderProducts { get; set; }

    public ICollection<RecipeProductsCreateDto?>? RecipeProducts { get; set; }
    
    public List<Guid>? RemovedStepIds { get; set; }
    
    public List<Guid>? RemovedRecipeProductIds { get; set; }
    
    public List<int>? RemovedGroupPositions { get; set; }
}