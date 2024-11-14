namespace Hospital_Management_System.Static.StatusCodeTypeMapper
{
    public class StatusCodeTypeMapper
    {
        public static string GetType(int statusCode)
        {
            return statusCode switch
            {
                StatusCodes.Status400BadRequest => "Bad Request",
                StatusCodes.Status401Unauthorized => "Unauthorized",
                StatusCodes.Status403Forbidden => "Forbidden",
                StatusCodes.Status404NotFound => "Not Found",
                StatusCodes.Status408RequestTimeout => "Request Timeout",
                StatusCodes.Status409Conflict => "Conflict",
                StatusCodes.Status422UnprocessableEntity => "Unprocessable Entity",
                StatusCodes.Status500InternalServerError => "Internal Server Error",
                StatusCodes.Status502BadGateway => "Bad Gateway",
                StatusCodes.Status503ServiceUnavailable => "Service Unavailable",
                StatusCodes.Status504GatewayTimeout => "Gateway Timeout",
                _ => "Unknown Error"
            };
        }
    }
}
