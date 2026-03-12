using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.Entities.Recipes;

public class RecipeProduct
{
    public Guid Id { get; set; }
    
    public Guid RecipeId { get; set; }
    
    public Guid ProductId { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string Description { get; set; } = "";
    
    public int SortOrder { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal Amount { get; set; }
    
    public int Kcal { get; set; }
    
    [Column(TypeName = "varchar(36)")]
    public required string Unit { get; set; }
    
    public Guid ActiveUnitId { get; set; }
    
    public int GroupPosition { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
    
    public Entities.Recipes.Recipe? Recipe { get; set; }
   
    public Entities.Recipes.Product? Product { get; set; }
}