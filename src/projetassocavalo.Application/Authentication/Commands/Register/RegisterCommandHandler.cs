using MediatR;
using OneOf;
using projetassocavalo.Application.Authentication.Common.Cryptography;
using projetassocavalo.Application.Authentication.Responses;
using projetassocavalo.Application.Errors;
using projetassocavalo.Application.Repositories;
using projetassocavalo.Domain.Entities;

namespace projetassocavalo.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, OneOf<RegisterResponse, AppError>>
{
    private readonly IUserRepository _userRepository;
    private readonly IBcryptNet _bcryptNet;

    public RegisterCommandHandler(IUserRepository userRepository, IBcryptNet bcryptNet)
    {
        _userRepository = userRepository;
        _bcryptNet = bcryptNet;
    }

    public async Task<OneOf<RegisterResponse, AppError>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userFinded = await _userRepository.FindUserByEmail(request.Email);

        if (userFinded != null)
        {
            return new UserAlreadyRegistered("User already registered");
        }
        var encryptPassword = _bcryptNet.EncryptPassword(request.Password);

        var newUser = User.CreateUser(request.Email, encryptPassword, request.UserName);

        var user = await  _userRepository.AddUser(newUser);

        return new RegisterResponse(user.Id, user.Username, user.Email);
    }
}