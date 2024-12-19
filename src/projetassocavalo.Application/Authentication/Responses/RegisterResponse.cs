namespace projetassocavalo.Application.Authentication.Responses;

public class RegisterResponse
{
    public RegisterResponse(Guid id, string name, string email)
    {
        Id = id;
        UserName = name;
        Email = email;
    }

    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}