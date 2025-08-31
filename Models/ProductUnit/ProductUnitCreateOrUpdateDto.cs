namespace BackendServer.Models;

public class ProductUnitCreateOrUpdateDto
{
    public Guid? Id { get; set; }
    
    public string Unit { get; set; }
    public decimal Amount { get; set; }
}