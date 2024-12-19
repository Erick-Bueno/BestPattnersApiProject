using projetassocavalo.Domain.Enums;

namespace projetassocavalo.Application.Errors;

public record ValidatorErrors(List<ValidationError> errors)
    : AppError("Validation errors" ,nameof(ValidatorErrors), TypeError.ValidationError.ToString(), errors);
 