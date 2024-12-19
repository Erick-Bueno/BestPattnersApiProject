using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using projetassocavalo.Application.Repositories;
using projetassocavalo.Domain.Entities;
using projetassocavalo.Infrastructure.Context;

namespace projetassocavalo.Infrastructure.Repositories;

public class TokenRepository : ITokenRepository
{
    private readonly AppDbContext _appDbContext;

    public TokenRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Token> CreateToken(Token token)
    {
        await _appDbContext.tokens.AddAsync(token);
        await _appDbContext.SaveChangesAsync();
        return token;
    }

    public async Task<Token> FindTokenByUserEmail(string email)
    {
        var token = await _appDbContext.tokens.Where(t => t.Email == email).FirstOrDefaultAsync();
        return token;
    }

    public async Task<Token> updateToken(Token token, string refreshToken)
    {
        var updatedToken =  Token.UpdateToken(token, refreshToken);
        await _appDbContext.SaveChangesAsync();
        return updatedToken;
    }
}