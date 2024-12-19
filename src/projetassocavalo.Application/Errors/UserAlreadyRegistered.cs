using projetassocavalo.Domain.Enums;

namespace projetassocavalo.Application.Errors;

public record UserAlreadyRegistered(string message) : AppError(message, nameof(UserAlreadyRegistered), TypeError.Conflict.ToString());