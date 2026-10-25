using BackendServer.Data;
using BackendServer.Models.Entities.IoBroker;

namespace BackendServer.Application.IoBroker.GraphQl;

[QueryType]
public static class FrontendLogsQuery
{
    [UseSorting]
    [UseFiltering]
    public static IQueryable<FrontendLog> GetFrontendLogs(AppDbContext dbContext)
    {
        return dbContext.FrontendLog;
    }
}