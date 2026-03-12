namespace BackendServer.Models.RecipeGroup;

public class RecipeGroupRemoveDto
{
    public Guid RecipeId { get; set; }

    public int Position { get; set; }
}