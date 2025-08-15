using System.ComponentModel.DataAnnotations.Schema;

namespace Rezepte.Models.Product;

public class Product
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal? Kcal { get; set; }
    
    public decimal? Fat { get; set; }
    
    public decimal? Sugar { get; set; }
    
    public decimal? Carbs { get; set; }
    
    public decimal? Protein { get; set; }
    
    public Guid? Category { get; set; }
    
    public decimal? Salt { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
    
    public decimal? Amount { get; set; }
    
    public string? Unit { get; set; }
    
    public ICollection<ProductUnit> ProductUnits { get; set; } = [];
}