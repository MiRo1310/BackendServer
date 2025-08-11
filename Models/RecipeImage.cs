namespace Rezepte.Models;

public class RecipeImage
{
    public Guid Id { get; set; }
    
    public string Url {get; set;}
    
    public Guid RecipeId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime ModifiedAt { get; set; }
}