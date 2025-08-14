namespace Rezepte.Models;

public class RecipeHeadersCreateDto
{
    public Guid Id { get; set; }
    
    public string Text { get; set; }
    
    public int Position { get; set; }
}