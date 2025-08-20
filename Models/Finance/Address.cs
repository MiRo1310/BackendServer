using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.Finance;

public class Address
{
    public Guid Id { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? Name { get; set; } = "";
    
    [Column(TypeName = "varchar(255)")]
    public string? Street { get; set; } = "";
    
    [Column(TypeName = "varchar(255)")]
    public string? City { get; set; } = "";
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }

    public ICollection<TravelCost> TravelCost { get; set; } = [];
}