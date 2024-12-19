using projetassocavalo.Domain.Enums;

namespace projetassocavalo.Application.Errors;

public record UserNotFound(string message) : AppError(message,nameof(UserNotFound), TypeError.Conflict.ToString());
