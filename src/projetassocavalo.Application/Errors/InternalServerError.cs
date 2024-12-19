using projetassocavalo.Domain.Enums;

namespace projetassocavalo.Application.Errors;

public record InternalServerError(string message) : AppError(message ,nameof(InternalServerError), TypeError.InternalServerError.ToString());
