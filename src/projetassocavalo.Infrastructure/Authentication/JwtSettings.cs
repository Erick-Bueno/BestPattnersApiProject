namespace projetassocavalo.Infrastructure.Authentication;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string? Issuer { get; init; }
    public string? Secretkey { get; init; }
    public int ExpiresIn { get; init; }
    public string? Audience { get; init; }
}