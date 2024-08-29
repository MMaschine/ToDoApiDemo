using System.Net;

namespace ToDoApp.Domain.Exceptions
{
    public class EntityValidationException(string errorMessage)
        : ApiErrorException(HttpStatusCode.UnprocessableEntity, errorMessage);

}
