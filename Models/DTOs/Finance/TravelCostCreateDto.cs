using System.Runtime.InteropServices.JavaScript;

namespace BackendServer.Models.Finance;

public class TravelCostCreateDto
{
    public DateOnly? Date { get; set; }
    
    public string? Description { get; set; }
    
    public Guid? AddressId { get; set; }
    public decimal? Price { get; set; }
}