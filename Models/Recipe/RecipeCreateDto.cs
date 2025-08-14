namespace Rezepte.Models;

public class RecipeCreateDto
{
    public required string Name { get; set; }

    public required int Portions { get; set; }

    public ICollection<RecipeHeaderCreateByRecipeDto?>? RecipeHeaders { get; set; } 
    
    public ICollection<RecipeTextAreaCreateDto?>? RecipeTextAreas { get; set; }
    
    public ICollection<RecipeHeaderProductCreateDto?>? RecipeHeaderProducts { get; set; }
    
    public ICollection<RecipeProductsCreateDto?>? RecipeProducts { get; set; }
}