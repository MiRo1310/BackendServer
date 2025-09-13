using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.Product;

public class  Product
{
    public Guid Id { get; init; }
    
    [Column(TypeName = "varchar(36)")]
    public required string Name { get; set; }
    
    [Column(TypeName = "varchar(36)")]
    public required string Unit { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal Amount { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Kcal { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Fat { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Sugar { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Carbs { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Protein { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Salt { get; set; }
    
    public Guid? Category { get; set; }
    
    public DateTime CreatedAt { get; init; }
    
    public DateTime? ModifiedAt { get; set; }
   
    public ICollection<ProductUnit.ProductUnit> ProductUnits { get; init; } = [];

    [ForeignKey("ProductId")]
    public ICollection<RecipeProduct.RecipeProduct> RecipeProducts { get; init; } = [];
    
    [ForeignKey("Category")]
    public ProductCategory.ProductCategory? ProductCategory { get; init; }
}