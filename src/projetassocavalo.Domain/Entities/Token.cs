namespace projetassocavalo.Domain.Entities;
public class Token : Entity
{
    public string RefreshToken { get; private set; }
    public string Email { get; private set; }

    public static Token CreateToken(string refreshToken, string email)
    {
        return new Token(){
            RefreshToken = refreshToken,
            Email = email
        };
    }
    public static Token UpdateToken(Token token, string refreshToken){
        token.RefreshToken = refreshToken;
        return token;
    }
}