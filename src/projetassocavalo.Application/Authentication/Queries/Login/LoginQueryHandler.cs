using MediatR;
using OneOf;
using projetassocavalo.Application.Authentication.Common.Authentication.Interfaces;
using projetassocavalo.Application.Authentication.Common.Cryptography;
using projetassocavalo.Application.Authentication.Responses;
using projetassocavalo.Application.Errors;
using projetassocavalo.Application.Repositories;
using projetassocavalo.Application.Tokens.Commands;
using projetassocavalo.Application.Tokens.Queries;
using projetassocavalo.Domain.Entities;

namespace projetassocavalo.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, OneOf<LoginResponse, AppError>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IBcryptNet _bcryptNet;
    private readonly ITokenRepository _tokenRepository;
    private readonly ISender _sender;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IBcryptNet bcryptNet, ITokenRepository tokenRepository, IFindTokenQueryHandler findTokenQueryHandler, ISender sender, IUpdateTokenCommandHandler updateTokenCommandHandler)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _bcryptNet = bcryptNet;
        _tokenRepository = tokenRepository;
        _sender = sender;
    }

    public async Task<OneOf<LoginResponse, AppError>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindUserByEmail(request.Email);

        if (user == null)
        {
            return new UserNotFound("User given email does not exist");
        }
        var verifyPassword = _bcryptNet.DecryptPassword(request.Password, user.Password);
        if (verifyPassword == false)
        {
            return new InvalidPassword("User given invalid password");
        }
        var accessToken = _jwtTokenGenerator.GenerateAccessToken(user.Id);
        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();
        
        //antes de criar o token verificar se o usuario ja logou no sistema anteriormente
        var findTokenQuery = new FindTokenQuery(user.Email);
        var findedToken = await _sender.Send(findTokenQuery);

        //atualizar o token se encontra um registro em token
        if(findedToken != null){
            var updateTokenCommand = new UpdateTokenCommand(findedToken, refreshToken);
            await  _sender.Send(updateTokenCommand);
            return new LoginResponse(user.Id, user.Email, refreshToken,accessToken);
        }


        var newToken = Token.CreateToken(refreshToken, user.Email);
        await _tokenRepository.CreateToken(newToken);

        return new LoginResponse(user.Id, user.Email, accessToken, refreshToken);
    }
}