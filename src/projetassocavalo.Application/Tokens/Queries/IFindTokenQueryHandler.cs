using MediatR;
using projetassocavalo.Domain.Entities;

namespace projetassocavalo.Application.Tokens.Queries;

public interface IFindTokenQueryHandler: IRequestHandler<FindTokenQuery, Token>
{
    
}