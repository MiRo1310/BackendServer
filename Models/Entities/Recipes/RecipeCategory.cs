using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.Entities.Recipes;

public class RecipeCategory
{
    public Guid Id { get; init; }

    [Column(TypeName = "varchar(255)")] 
    public string Name { get; set; } = "";
    
    public DateTime CreatedAt { get; init; }

    public DateTime? ModifiedAt { get; set; }
}