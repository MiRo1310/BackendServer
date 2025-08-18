namespace BackendServer.Models.Finance;

public class Listing
{
    public Guid? Id { get; set; }
    
    public DateTime? Date { get; set; }
    
    public string? Description { get; set; }
    
    public decimal? Price { get; set; }
}