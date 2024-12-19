using MediatR;
using projetassocavalo.Domain.Entities;

namespace projetassocavalo.Application.Tokens.Commands;

public record UpdateTokenCommand(Token token , string refreshToken) : IRequest<Unit>;