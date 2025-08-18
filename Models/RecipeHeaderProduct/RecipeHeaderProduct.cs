using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models;

[Table("recipesHeaderProducts")]
public class RecipeHeaderProduct
{
    public Guid Id { get; set; }

    public Guid RecipeId { get; set; }

    public string Text { get; set; }

    public int Position { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public Recipe.Recipe Recipe { get; set; }
}