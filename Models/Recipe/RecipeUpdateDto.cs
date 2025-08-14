namespace Rezepte.Models;

public class RecipeUpdateDto
{
    public required Guid Id { get; set; }

    public string? Name { get; set; }

    public int? Portions { get; set; }
    
    public ICollection<RecipeHeaderCreateOrUpdateDto?>? RecipeHeaders { get; set; } 
    
    public ICollection<RecipeTextAreaUpdateDto?>? RecipeTextAreas { get; set; }
    
    public ICollection<RecipeHeaderProductUpdateDto?>? RecipeHeaderProducts { get; set; }
    
    public ICollection<RecipeProductsUpdateDto?>? RecipeProducts { get; set; }

}