namespace BackendServer.Models;

public class ProductCategoryUpdateDto
{
    public required Guid Id { get; set; }
    public required string  Name { get; set; }
}