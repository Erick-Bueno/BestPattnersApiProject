using projetassocavalo.Application.Authentication.Common.Cryptography;

namespace projetassocavalo.Infrastructure.Cryptography;

public class BcryptNet : IBcryptNet
{
    public bool DecryptPassword(string password, string encryptPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, encryptPassword);
    }

    public string EncryptPassword(string password)
    {
        var encryptPassword = BCrypt.Net.BCrypt.HashPassword(password);
        return encryptPassword;
    }
}