using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.Entities.Recipes;

public class Recipe
{
    public Guid Id { get; init; }

    [Column(TypeName = "varchar(255)")] 
    public string Name { get; set; } = "";

    public int? Portions { get; set; }

    public int TotalKcal { get; set; }
    
    public DateTime CreatedAt { get; init; }

    public DateTime? ModifiedAt { get; set; }


    public ICollection<RecipeProduct> RecipeProducts { get; init; } = [];

    public ICollection<RecipeDescription> RecipeDescriptions { get; init; } = [];

    public ICollection<RecipeProductHeader> RecipeHeaderProducts { get; init; } = [];
}