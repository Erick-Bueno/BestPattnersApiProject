namespace projetassocavalo.Domain.Entities;

public class User : Entity
{

    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public static User CreateUser(string email, string password, string userName)
    {
        return new User()
        {
            Email = email,
            Password = password,
            Username = userName
        };
    }

}