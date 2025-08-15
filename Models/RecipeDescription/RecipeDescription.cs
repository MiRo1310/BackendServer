using System.ComponentModel.DataAnnotations.Schema;

namespace Rezepte.Models.RecipeDescription;

public class RecipeDescription
{
    public Guid Id { get; set; }
    
    public Guid RecipeId { get; set; }
    
    public string Text { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public string Header { get; set; }
    
    public int Position { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
    
    public Recipe.Recipe? Recipe { get; set; }
}