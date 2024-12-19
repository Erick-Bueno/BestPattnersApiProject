using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using projetassocavalo.Application.Behaviors;
using projetassocavalo.Application.Tokens.Commands;
using projetassocavalo.Application.Tokens.Queries;
namespace projetassocavalo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)); //faz a injecao pra todos os validators
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IFindTokenQueryHandler, FindTokenQueryHandler>();
        services.AddScoped<IUpdateTokenCommandHandler, UpdateTokenCommandHandler>();
        return services;
    }
}