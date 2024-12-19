using System.Data;
using FluentValidation;

namespace projetassocavalo.Application.Authentication.Commands.Register;


public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(r => r.Email)
        .NotEmpty()
        .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Invalid Email");
        RuleFor(l => l.Password)
        .NotEmpty()
        .Matches(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").WithMessage("The password must contain at least 8 characters, a stored letter, a number and a special character");
        RuleFor(r => r.UserName)
        .NotEmpty();
    }
}