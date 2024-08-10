using System.Net;

namespace ToDoApp.Domain.Exceptions
{
    public class FieldValidationErrorException(string fieldName, string errorMessage)
        : ApiErrorException(HttpStatusCode.UnprocessableEntity,
            $"Validation for the field {fieldName} failed. Error message: {errorMessage}");

}
