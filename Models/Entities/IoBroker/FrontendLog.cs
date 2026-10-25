using System.ComponentModel.DataAnnotations.Schema;
using BackendServer.Application.Enum;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Models.Entities.IoBroker;

[Index(nameof(CreatedAt))]
[Index(nameof(DeviceId), nameof(CreatedAt))]
public class  FrontendLog
{
    public Guid Id { get; init; }

    [Column(TypeName = "varchar(255)")]
    public required string Title { get; set; }

    [Column(TypeName = "varchar(512)")]
    public required string DeviceName { get; set; }

    [Column(TypeName = "varchar(50)")]
    public required string DeviceId { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string? AppVersion { get; set; } = null;

    [Column(TypeName = "varchar(255)")]
    public string? Route { get; set; } = null;

    [Column(TypeName = "varchar(45)")]
    public string? IP { get; set; } = null;

    [Column(TypeName = "longtext")]
    public string? Description { get; set; } = null;

    [Column(TypeName =  "varchar(14)")]
    public LoggingLevel Level { get; set; }

    public DateTime CreatedAt { get; init; }
}
