using BackendServer.Application.Enum;

namespace BackendServer.Models.DTOs.IoBroker.FrontendLogs;

public class FrontendLogCreateDto
{
    public required string Title { get; set; }

    public required string DeviceName { get; set; }

    public required string DeviceId { get; set; }

    public string? AppVersion { get; set; }

    public string? Route { get; set; }

    public string? Description { get; set; }

    public required LoggingLevel Level { get; set; }
}
