using FluentValidation;
using MediatR;
using OneOf;
using projetassocavalo.Application.Errors;
namespace projetassocavalo.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
where TRequest : IRequest<TResponse>
where TResponse :IOneOf
{
    private readonly IValidator<TRequest> _validator;

    public ValidationBehavior(IValidator<TRequest> validator)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors.ConvertAll(validationFailure => new ValidationError()
        {
            Code = validationFailure.ErrorMessage,
            Description = validationFailure.PropertyName
        });
        return (dynamic) new ValidatorErrors(errors);
    }
}