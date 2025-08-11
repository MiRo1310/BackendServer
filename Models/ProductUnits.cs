namespace Rezepte.Models;

public class ProductUnits
{
    public Guid Id { get; set; }
    
    public string Unit { get; set; }
    
    public int DefaultUnit { get; set; }
    
    public decimal Amount { get; set; }
    
    public Guid ProductId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime ModifiedAt { get; set; }
}