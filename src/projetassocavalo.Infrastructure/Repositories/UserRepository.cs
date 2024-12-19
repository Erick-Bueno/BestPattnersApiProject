using Microsoft.EntityFrameworkCore;
using projetassocavalo.Application.Repositories;
using projetassocavalo.Domain.Entities;
using projetassocavalo.Infrastructure.Context;

namespace projetassocavalo.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<User> FindUserByEmail(string email)
    {
        var user = await _appDbContext.users.Where(u => u.Email == email).FirstOrDefaultAsync();
        return user;
    }

    public async Task<User> AddUser(User user)
    {
        await _appDbContext.AddAsync(user);
        await _appDbContext.SaveChangesAsync();
        return  user;
    }
}