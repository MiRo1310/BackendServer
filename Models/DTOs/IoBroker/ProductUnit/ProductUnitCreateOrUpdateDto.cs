namespace BackendServer.Models.DTOs.IoBroker;

public class ProductUnitCreateOrUpdateDto
{
    public Guid? Id { get; set; }
    
    public required string Unit { get; set; }
    public decimal Amount { get; set; }
}