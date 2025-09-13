namespace BackendServer.Models.RecipeProductHeader;

public abstract class RecipeHeaderProductCreateOrUpdateDto
{
    public Guid? Id { get; set; }

    public Guid? RecipeId { get; set; }

    public required string Text { get; set; }

    public int Position { get; set; }
}