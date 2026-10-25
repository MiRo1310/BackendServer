using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.DTOs.IoBroker;

public class UnitUpdateDto
{
    public Guid Id { get; set; }
    
    [Column(TypeName = "varchar(36)")]
    public required string Name { get; set; }
}