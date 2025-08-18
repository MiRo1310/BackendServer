namespace Rezepte.Models;

public class ProductCreateDto
{
    public string Name { get; set; }
    
    public decimal? Kcal { get; set; }
    
    public decimal? Fat { get; set; }
    
    public decimal? Carbs { get; set; }
    
    public decimal? Protein { get; set; }
    
    public Guid? Category { get; set; }
    
    public decimal? Sugar { get; set; }
    
    public decimal? Salt { get; set; }
    
    public decimal Amount { get; set; }
    
    public string? Unit { get; set; }
    
    public ICollection<ProductUnitCreateOrUpdateDto?>? ProductUnits { get; set; } = [];
}