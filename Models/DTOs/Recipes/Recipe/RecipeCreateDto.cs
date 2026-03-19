using BackendServer.Models.RecipeDescription;
using BackendServer.Models.RecipeProduct;
using BackendServer.Models.RecipeProductHeader;

namespace BackendServer.Models.DTOs.Recipes.Recipe;

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