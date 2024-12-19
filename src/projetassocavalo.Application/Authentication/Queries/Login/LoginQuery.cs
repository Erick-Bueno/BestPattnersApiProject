using MediatR;
using OneOf;
using projetassocavalo.Application.Authentication.Responses;
using projetassocavalo.Application.Errors;

namespace projetassocavalo.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<OneOf<LoginResponse,AppError>> ;
