namespace projetassocavalo.Application.Authentication.Responses;

public class LoginResponse
{
    public LoginResponse(Guid id, string email, string refreshToken, string accessToken)
    {
        Id = id;
        Email = email;
        RefreshToken = refreshToken;
        AccessToken = accessToken;
    }

    public Guid Id { get; set; }
    public string Email { get; set; }
    public string RefreshToken { get; set; }
    public string AccessToken { get; set; }
    
}