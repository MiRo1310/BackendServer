namespace BackendServer.Models.DTOs.IoBroker;

public class ProductCategoryUpdateDto
{
    public required Guid Id { get; set; }
    public required string  Name { get; set; }
}