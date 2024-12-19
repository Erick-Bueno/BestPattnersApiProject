using projetassocavalo.Domain.Enums;

namespace projetassocavalo.Application.Errors;
public record InvalidPassword(string message) : AppError(message,nameof(InvalidPassword), TypeError.Conflict.ToString());