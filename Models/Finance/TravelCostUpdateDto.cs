namespace BackendServer.Models.Finance;

public class TravelCostUpdateDto
{
    public Guid? Id { get; set; }
    
    public DateOnly? Date { get; set; }
    
    public string? Description { get; set; }
    
    public Guid? AddressId { get; set; }
    public decimal? Price { get; set; }
}