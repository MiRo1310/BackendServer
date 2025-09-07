using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.Finance;

public class TravelCost
{
    public Guid Id { get; init; }
    
    public DateOnly? Date { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public string? Description { get; set; }
    
    public Guid? AddressId { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Price { get; set; }
    
    public DateTime CreatedAt { get; init; }
    
    public DateTime? ModifiedAt { get; set; }
    
    public Address Address { get; set; }
}