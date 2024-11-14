namespace Hospital_Management_System.Static.ExceptionStatusMapper
{
    public class ExceptionStatusMapper
    {
        public static int GetStatusCode(Exception exception)
        {
            return exception switch
            {
                ArgumentNullException => StatusCodes.Status400BadRequest,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                InvalidOperationException => StatusCodes.Status403Forbidden,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                TaskCanceledException => StatusCodes.Status408RequestTimeout,
                ApplicationException => StatusCodes.Status409Conflict,
                FormatException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError,
            };
        }
    }
}
