using projetassocavalo.Domain.Entities;

namespace projetassocavalo.Application.Repositories;

public interface IUserRepository
{
    public Task<User> FindUserByEmail(string email);
    public Task<User> AddUser(User user);
}