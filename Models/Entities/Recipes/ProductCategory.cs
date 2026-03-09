using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.Entities.Recipes;

public class ProductCategory
{
    public Guid Id { get; set; }
    
    [Column(TypeName = "varchar(36)")]
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
    
    public ICollection<Product> Products { get; set; } = [];
}