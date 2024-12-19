using MediatR;

namespace projetassocavalo.Application.Tokens.Commands;

public interface IUpdateTokenCommandHandler : IRequestHandler<UpdateTokenCommand, Unit>
{
    
}