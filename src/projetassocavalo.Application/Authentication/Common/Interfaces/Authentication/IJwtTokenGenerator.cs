namespace projetassocavalo.Application.Authentication.Common.Authentication.Interfaces;

public interface IJwtTokenGenerator
{
    public string GenerateAccessToken(Guid userId);
    public string GenerateRefreshToken();
}