using projetassocavalo.Domain.Entities;

namespace projetassocavalo.Application.Repositories;
public interface ITokenRepository
{
    public Task<Token> CreateToken (Token token);
    public Task<Token> FindTokenByUserEmail(string email);
    public Task<Token> UpdateToken(Token token,string refreshToken);
}
