using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.DTOs.IoBroker.Unit;

public class UnitCreateDto
{
    [Column(TypeName = "varchar(36)")]
    public required string Name { get; set; }
}