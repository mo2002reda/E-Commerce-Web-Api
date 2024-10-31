using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.HandleResponse
{
    public class Response
    {
        public Response(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                100 => "Continue",
                101 => "SwitchingProtocols",
                200 => "OK",
                201 => "Created",
                202 => "Accepted",
                203 => "NonAuthoritativeInformation",
                204 => "NoContent",
                205 => "ResetContent",
                206 => "PartialContent",
                300 => "MultipleChoices",
                301 => "MovedPermanently",
                302 => "Found",
                303 => "SeeOther",
                304 => "NotModified",
                305 => "UseProxy",
                307 => "TemporaryRedirect",
                400 => "BadRequest",
                401 => "Unauthorized",
                402 => "PaymentRequired",
                403 => "Forbidden",
                404 => "NotFound",
                405 => "MethodNotAllowed",
                406 => "NotAcceptable",
                407 => "ProxyAuthenticationRequired",
                408 => "RequestTimeout",
                409 => "Conflict",
                410 => "Gone",
                411 => "LengthRequired",
                412 => "PreconditionFailed",
                413 => "RequestEntityTooLarge",
                414 => "RequestUriTooLong",
                415 => "UnsupportedMediaType",
                416 => "RequestedRangeNotSatisfiable",
                417 => "ExpectationFailed",
                426 => "UpgradeRequired",
                500 => "InternalServerError",
                501 => "NotImplemented",
                502 => "BadGateway",
                503 => "ServiceUnavailable",
                504 => "GatewayTimeout",
                505 => "HttpVersionNotSupported",
                _ => "UnknownStatusCode" // Default case if the statusCode does not match any of the specified cases
            };
        }



    }
}
