namespace Rezepte.Models;

public class RecipeCreateDto
{
    public required string Name { get; set; }

    public required int Portions { get; set; }
}