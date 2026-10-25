namespace BackendServer.Models.DTOs.IoBroker;

public class RecipeCategoryUpdateDto
{
    public required Guid Id { get; set; }
    public required string  Name { get; set; }
}