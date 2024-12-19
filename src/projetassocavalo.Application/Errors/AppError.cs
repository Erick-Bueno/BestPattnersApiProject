using projetassocavalo.Domain.Enums;

namespace projetassocavalo.Application.Errors;

public record AppError(string detail, string NameError, string ErrorType ,List<ValidationError>? ValidationErrors = null);