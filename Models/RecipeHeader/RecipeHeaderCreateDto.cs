namespace Rezepte.Models;

public class RecipeHeaderCreateDto
{
    public Guid RecipeId { get; set; }
    public string Text { get; set; }
    
    public int Position { get; set; }
}