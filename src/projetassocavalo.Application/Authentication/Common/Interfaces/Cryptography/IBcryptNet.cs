namespace projetassocavalo.Application.Authentication.Common.Cryptography;

public interface IBcryptNet
{
    public string EncryptPassword(string password);
    public bool DecryptPassword(string password, string encryptPassword);
}