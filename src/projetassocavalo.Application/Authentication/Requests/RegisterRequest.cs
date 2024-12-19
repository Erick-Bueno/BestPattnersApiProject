namespace projetassocavalo.Application.Authentication.Requests;

public record RegisterRequest(
    string UserName,
    string Password, 
    string Email
);