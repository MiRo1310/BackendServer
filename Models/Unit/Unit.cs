using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.Unit;

public class Unit
{
    public Guid Id { get; init; }
    
    [Column(TypeName = "varchar(36)")]
    public required string Name { get; set; }
    
    public DateTime CreatedAt { get; init; }
    
    public DateTime? ModifiedAt { get; set; }
    
}