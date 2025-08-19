namespace BackendServer.Models.Finance;

public class TravelCost
{
    public Guid Id { get; set; }
    
    public DateOnly? Date { get; set; }
    
    public string? Description { get; set; }
    
    public Guid? AddressId { get; set; }
    
    public decimal? Price { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
    
    public Address Address { get; set; }
}