using BackendServer.Application.Enum;

namespace BackendServer.Application.Common.GraphQl;

[QueryType]
public static class EnumQuery
{
    
    public static IEnumerable<ErrorCode> GetErrorCodes()
    {
        return System.Enum.GetValues<ErrorCode>().Cast<ErrorCode>();
    }
}