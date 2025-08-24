using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.Product;

public class  Product
{
    public Guid Id { get; set; }
    
    [Column(TypeName = "varchar(36)")]
    public string Name { get; set; }
    
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
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
   
    
    public ICollection<ProductUnit.ProductUnit> ProductUnits { get; set; } = [];

    public ICollection<RecipeProduct.RecipeProduct> RecipeProducts { get; set; } = [];
}