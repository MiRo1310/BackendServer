namespace BackendServer.Models.Finance;

public abstract class AddressUpdateDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; } = "";
    
    public string? Street { get; set; } = "";
    
    public string? City { get; set; } = "";
}