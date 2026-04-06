using BackendServer.Enum;

namespace BackendServer.Models.DTOs;

public  class Response<T>(T? value, ErrorCode errorCode, bool isError = false  )
{

    public bool IsError { get; set; } = isError;

    public T? Data { get; set; }= value;

    public ErrorCode ErrorCode { get; set; } = errorCode;
}