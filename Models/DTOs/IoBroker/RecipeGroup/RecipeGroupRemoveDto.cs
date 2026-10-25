namespace BackendServer.Models.DTOs.IoBroker;

public class RecipeGroupRemoveDto
{
    public Guid RecipeId { get; set; }

    public int Position { get; set; }
}