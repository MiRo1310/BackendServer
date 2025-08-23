namespace BackendServer.Models;

public class RecipeHeaderProductCreateOrUpdateDto
{
    public Guid? Id { get; set; }

    public Guid? RecipeId { get; set; }

    public string Text { get; set; }

    public int Position { get; set; }
}