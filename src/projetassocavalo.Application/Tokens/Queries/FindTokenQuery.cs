using MediatR;
using projetassocavalo.Domain.Entities;

namespace projetassocavalo.Application.Tokens.Queries;

public record FindTokenQuery(string email) : IRequest<Token>;