namespace Rezepte.Models;

public class RecipeTextAreaCreateOrUpdateDto
{
    public Guid? Id { get; set; }
    
    public string Text { get; set; }
    
    public int Position { get; set; }
}