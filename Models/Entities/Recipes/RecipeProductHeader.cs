using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.Entities.Recipes;

public class RecipeProductHeader
{
    public Guid Id { get; set; }

    public Guid RecipeId { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string Text { get; set; } ="";

    public int Position { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public Recipe? Recipe { get; set; }
}