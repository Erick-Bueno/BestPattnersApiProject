using MediatR.Registration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using projetassocavalo.Application.Authentication.Common.Authentication.Interfaces;
using projetassocavalo.Application.Authentication.Common.Cryptography;
using projetassocavalo.Application.Repositories;
using projetassocavalo.Application.Services;
using projetassocavalo.Infrastructure.Authentication;
using projetassocavalo.Infrastructure.Context;
using projetassocavalo.Infrastructure.Cryptography;
using projetassocavalo.Infrastructure.Repositories;
using projetassocavalo.Infrastructure.Services;

namespace projetassocavalo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("default")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITokenRepository, TokenRepository>();
        services.AddScoped<IBcryptNet, BcryptNet>();
        return services;
    }
}