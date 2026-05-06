using System.Text.Json;
using FluentValidation.Results;
using JungleBackend.Domain.Shared;

namespace JungleBackend.Application.Validation.ValidationExtensions;

public static class ValidationExtensions
{
    public static Error ToError(this ValidationResult validationResult)
    {
        List<ValidationFailure> validationErrors = validationResult.Errors;

        IEnumerable<string[]> errors = from validationError in validationErrors
            let errorMessage = validationError.ErrorMessage
            let error = JsonSerializer.Deserialize<Error>(errorMessage)
            select error.Messages;

        return Error.Validation(null, errors.SelectMany(x => x).ToArray());
    }
}