using MediatR;
using OneOf;
using projetassocavalo.Application.Authentication.Responses;
using projetassocavalo.Application.Errors;

namespace projetassocavalo.Application.Authentication.Commands.Register;

public record RegisterCommand(string UserName, string Email, string Password) : IRequest<OneOf<RegisterResponse,AppError>>;