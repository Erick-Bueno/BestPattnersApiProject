using MediatR;
using projetassocavalo.Application.Repositories;

namespace projetassocavalo.Application.Tokens.Commands;

public class UpdateTokenCommandHandler : IUpdateTokenCommandHandler
{
    private readonly ITokenRepository _tokenRepository;

    public UpdateTokenCommandHandler(ITokenRepository tokenRepository)
    {
        _tokenRepository = tokenRepository;
    }

    public async Task<Unit> Handle(UpdateTokenCommand request, CancellationToken cancellationToken)
    {
       await _tokenRepository.UpdateToken(request.token, request.refreshToken);
       return Unit.Value;
    }
}