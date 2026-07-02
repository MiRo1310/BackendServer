namespace BackendServer.Models.DTOs.Finance;

public class AddressCreateDto
{
    public string? Name { get; set; } = "";
    
    public string? Street { get; set; } = "";
    
    public string? City { get; set; } = "";
}