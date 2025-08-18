namespace BackendServer.Models.Finance;

public class Addresses
{
    public Guid Id { get; set; }

    public string? Name { get; set; } = "";
    
    public string? Street { get; set; } = "";
    
    public string? City { get; set; } = "";
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
    
}