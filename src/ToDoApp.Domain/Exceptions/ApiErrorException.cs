using System.Net;

namespace ToDoApp.Domain.Exceptions
{
    public class ApiErrorException(HttpStatusCode statusCode, string errorMessage) : Exception(errorMessage)
    {
        public ApiError ApiError => new()
        {
            StatusCode = statusCode,
            Message = Message
        };
    }
}
