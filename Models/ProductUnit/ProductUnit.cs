using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.ProductUnit;

public class ProductUnit
{
    public Guid Id { get; set; }
    
    [Column(TypeName = "varchar(20)")]
    public string Unit { get; set; }
    
    [Column(TypeName = "decimal(12,4)")]
    public decimal? Amount { get; set; }
   
    public Guid ProductId { get; set; }
    
    public bool IsDefault { get; set; }

    public bool Active { get; set; } = false;
    
    [Column(TypeName = "decimal(12,4)")]
    public decimal Faktor { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
    
    public Product.Product? Product { get; set; }
}