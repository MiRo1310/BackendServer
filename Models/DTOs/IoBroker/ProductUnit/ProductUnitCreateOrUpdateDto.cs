namespace BackendServer.Models.DTOs.IoBroker;

public class ProductUnitCreateOrUpdateDto
{
    public Guid? Id { get; set; }
    
    public Guid UnitId { get; set; }
    public decimal Amount { get; set; }
}