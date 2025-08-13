using System.ComponentModel.DataAnnotations.Schema;

namespace Rezepte.Models;

[Table("recipeImages")]

public class RecipeImage
{
    public Guid Id { get; set; }
    
    public string Url {get; set;}
    
    public Guid RecipeId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime ModifiedAt { get; set; }
    
    public Recipe? Recipe { get; set; }
}