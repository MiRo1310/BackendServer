using System.ComponentModel.DataAnnotations.Schema;

namespace Rezepte.Models;

[Table("recipes")]
public class Recipe
{
    public Guid Id { get; set; } 

    public string Name { get; set; }

    public decimal Portions { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
    
    public ICollection<RecipeHeader> Headers { get; set; } = [];
  
    public ICollection<RecipeProduct> RecipeProducts { get; set; } = [];
    
    public ICollection<RecipeTextArea> RecipeTextAreas { get; set; } = [];
    
    public ICollection<RecipeHeaderProduct> RecipeHeaderProducts { get; set; } = [];
}