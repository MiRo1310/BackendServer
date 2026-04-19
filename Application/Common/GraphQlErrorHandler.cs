using System.Net;
using BackendServer.Application.Enum;

namespace BackendServer.Application.Common;

public static class GraphQlErrorHandler
{

    public static void Custom(string message, ErrorCode code)
    {
        throw new GraphQLException(
            ErrorBuilder.New()
                .SetMessage(message)
                .SetCode(code.ToString())
                .Build());
    }
    
    public static void HttpResponse(HttpResponseMessage response)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.NotFound:
                throw new GraphQLException(
                    ErrorBuilder.New()
                        .SetMessage("Not found")
                        .SetCode(nameof(ErrorCode.NotFound))
                        .Build());
            case HttpStatusCode.GatewayTimeout:
                throw new GraphQLException(
                    ErrorBuilder.New()
                        .SetMessage("Gateway timeout").SetCode(nameof(HttpStatusCode.GatewayTimeout)).Build());
            case HttpStatusCode.Continue:
                break;
            case HttpStatusCode.SwitchingProtocols:
                break;
            case HttpStatusCode.Processing:
                break;
            case HttpStatusCode.EarlyHints:
                break;
            case HttpStatusCode.OK:
                break;
            case HttpStatusCode.Created:
                break;
            case HttpStatusCode.Accepted:
                break;
            case HttpStatusCode.NonAuthoritativeInformation:
                break;
            case HttpStatusCode.NoContent:
                break;
            case HttpStatusCode.ResetContent:
                break;
            case HttpStatusCode.PartialContent:
                break;
            case HttpStatusCode.MultiStatus:
                break;
            case HttpStatusCode.AlreadyReported:
                break;
            case HttpStatusCode.IMUsed:
                break;
            case HttpStatusCode.Ambiguous:
                break;
            case HttpStatusCode.Moved:
                break;
            case HttpStatusCode.Found:
                break;
            case HttpStatusCode.RedirectMethod:
                break;
            case HttpStatusCode.NotModified:
                break;
            case HttpStatusCode.UseProxy:
                break;
            case HttpStatusCode.Unused:
                break;
            case HttpStatusCode.RedirectKeepVerb:
                break;
            case HttpStatusCode.PermanentRedirect:
                break;
            case HttpStatusCode.BadRequest:
                break;
            case HttpStatusCode.Unauthorized:
                break;
            case HttpStatusCode.PaymentRequired:
                break;
            case HttpStatusCode.Forbidden:
                break;
            case HttpStatusCode.MethodNotAllowed:
                break;
            case HttpStatusCode.NotAcceptable:
                break;
            case HttpStatusCode.ProxyAuthenticationRequired:
                break;
            case HttpStatusCode.RequestTimeout:
                break;
            case HttpStatusCode.Conflict:
                break;
            case HttpStatusCode.Gone:
                break;
            case HttpStatusCode.LengthRequired:
                break;
            case HttpStatusCode.PreconditionFailed:
                break;
            case HttpStatusCode.RequestEntityTooLarge:
                break;
            case HttpStatusCode.RequestUriTooLong:
                break;
            case HttpStatusCode.UnsupportedMediaType:
                break;
            case HttpStatusCode.RequestedRangeNotSatisfiable:
                break;
            case HttpStatusCode.ExpectationFailed:
                break;
            case HttpStatusCode.MisdirectedRequest:
                break;
            case HttpStatusCode.UnprocessableEntity:
                break;
            case HttpStatusCode.Locked:
                break;
            case HttpStatusCode.FailedDependency:
                break;
            case HttpStatusCode.UpgradeRequired:
                break;
            case HttpStatusCode.PreconditionRequired:
                break;
            case HttpStatusCode.TooManyRequests:
                break;
            case HttpStatusCode.RequestHeaderFieldsTooLarge:
                break;
            case HttpStatusCode.UnavailableForLegalReasons:
                break;
            case HttpStatusCode.InternalServerError:
                break;
            case HttpStatusCode.NotImplemented:
                break;
            case HttpStatusCode.BadGateway:
                break;
            case HttpStatusCode.ServiceUnavailable:
                break;
            case HttpStatusCode.HttpVersionNotSupported:
                break;
            case HttpStatusCode.VariantAlsoNegotiates:
                break;
            case HttpStatusCode.InsufficientStorage:
                break;
            case HttpStatusCode.LoopDetected:
                break;
            case HttpStatusCode.NotExtended:
                break;
            case HttpStatusCode.NetworkAuthenticationRequired:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}