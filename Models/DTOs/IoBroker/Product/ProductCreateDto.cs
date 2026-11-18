namespace BackendServer.Models.DTOs.IoBroker;

public class ProductCreateDto
{
    public required string Name { get; set; }
    
    public string? Ean { get; set; }
    
    public decimal? Kcal { get; set; }
    
    public decimal? Fat { get; set; }
    
    public decimal? Carbs { get; set; }
    
    public decimal? Protein { get; set; }
    
    public Guid? Category { get; set; }
    
    public decimal? Sugar { get; set; }
    
    public decimal? Salt { get; set; }
    
    public decimal Amount { get; set; }
    
    public Guid UnitId { get; set; }
    
    public ICollection<ProductUnitCreateOrUpdateDto?>? ProductUnits { get; set; } = [];
}