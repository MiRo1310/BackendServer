namespace BackendServer.Models.DTOs.Finance;

public class TravelCostUpdateDto
{
    public Guid? Id { get; set; }
    
    public DateOnly? Date { get; set; }
    
    public string? Description { get; set; }
    
    public Guid? AddressId { get; set; }
    public decimal? Price { get; set; }
    
    public bool? IsValidated { get; set; }
    
    public bool? HasInvoice { get; set; }
}