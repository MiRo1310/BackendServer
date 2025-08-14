using Rezepte.Enum;

namespace Rezepte.Types;

public  class ResponseObject<T>(T? value, ErrorCode errorCode, bool isError = false  )
{

    public  bool IsError { get; set; } = isError;
    

    public T? Data { get; set; }= value;

    public ErrorCode ErrorCode { get; set; } = errorCode;

}