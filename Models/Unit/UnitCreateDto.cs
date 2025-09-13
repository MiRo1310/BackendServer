using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.Unit;

public class UnitCreateDto
{
    [Column(TypeName = "varchar(36)")]
    public required string Name { get; set; }
}