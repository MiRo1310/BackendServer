using BackendServer.Application.Common;
using BackendServer.Application.Enum;
using BackendServer.Data;
using BackendServer.Models.DTOs.IoBroker.FrontendLogs;
using BackendServer.Models.Entities.IoBroker;

namespace BackendServer.Application.IoBroker.GraphQl;

[MutationType]

public static class FrontendLogMutation
{
    public static FrontendLog CreateFrontendLog(AppDbContext dbContext, HttpContext httpContext, FrontendLogCreateDto dto)
    {
        var log = new FrontendLog()
        {
            Id = Guid.NewGuid(),
           Title = dto.Title,
           Description = dto.Description,
           DeviceId =  dto.DeviceId,
           DeviceName =  dto.DeviceName,
           AppVersion =  dto.AppVersion,
           Level =  dto.Level,
           Route =   dto.Route,
            CreatedAt = DateTime.UtcNow,
            IP = httpContext.Connection.RemoteIpAddress?.ToString()
        };

        dbContext.FrontendLog.Add(log);
        dbContext.SaveChanges();
        return log;
    }

    public static bool RemoveFrontendLog(AppDbContext dbContext, Guid id)
    {
        var log = dbContext.FrontendLog.FirstOrDefault(unit => unit.Id == id);

        if (log is null)
        {
            GraphQlErrorHandler.Custom("Log not found", ErrorCode.NotFound);
            return false;
        }

        dbContext.FrontendLog.Remove(log);
        dbContext.SaveChanges();

        return true;
    }
}