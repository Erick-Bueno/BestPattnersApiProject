using MediatR;
using projetassocavalo.Application.Repositories;
using projetassocavalo.Domain.Entities;

namespace projetassocavalo.Application.Tokens.Queries;

public class FindTokenQueryHandler : IFindTokenQueryHandler
{
    private readonly ITokenRepository _tokenRepository;

    public FindTokenQueryHandler(ITokenRepository tokenRepository)
    {
        _tokenRepository = tokenRepository;
    }

    public async Task<Token> Handle(FindTokenQuery request, CancellationToken cancellationToken)
    {
        var token = await _tokenRepository.FindTokenByUserEmail(request.email);
        return token;
    }
}