using FluentValidation;

namespace projetassocavalo.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(l => l.Email)
        .NotEmpty()
        .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Invalid Email");
        RuleFor(l => l.Password)
        .NotEmpty()
        .Matches(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").WithMessage("The password must contain at least 8 characters, a stored letter, a number and a special character");
    }

}