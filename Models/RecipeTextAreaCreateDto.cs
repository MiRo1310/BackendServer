namespace Rezepte.Models;

public class RecipeTextAreaCreateDto
{
    public Guid Id { get; set; }
    
    public string Text { get; set; }
    
    public int Position { get; set; }
}