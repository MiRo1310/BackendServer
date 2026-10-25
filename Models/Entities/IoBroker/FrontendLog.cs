using System.ComponentModel.DataAnnotations.Schema;
using BackendServer.Application.Enum;

namespace BackendServer.Models.Entities.IoBroker;

public class  FrontendLog
{
    public Guid Id { get; init; }

    [Column(TypeName = "varchar(100)")]
    public required string Title { get; set; }

    [Column(TypeName = "varchar(100)")]
    public required string DeviceName { get; set; }

    [Column(TypeName = "varchar(50)")]
    public required string DeviceId { get; set; }

    [Column(TypeName = "varchar(10)")]
    public string? AppVersion { get; set; } = null;

    [Column(TypeName = "varchar(50)")]
    public string? Route { get; set; } = null;

    [Column(TypeName = "longtext")]
    public string? Description { get; set; } = null;

    [Column(TypeName =  "varchar(14)")]
    public LoggingLevel Level { get; set; }

    public DateTime CreatedAt { get; init; }
}
