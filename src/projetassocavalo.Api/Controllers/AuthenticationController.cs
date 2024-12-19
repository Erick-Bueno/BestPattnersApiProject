using MediatR;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using projetassocavalo.Application.Authentication.Commands.Register;
using projetassocavalo.Application.Authentication.Queries.Login;
using projetassocavalo.Application.Authentication.Requests;
using projetassocavalo.Application.Authentication.Responses;
using projetassocavalo.Application.Errors;
using projetassocavalo.Application.Extension;

namespace projetassocavalo.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var result = await _mediator.Send(query);
        return this.LoginResponseBase(result);
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.UserName,request.Email, request.Password);
        var result = await _mediator.Send(command);
        return this.RegisterResponseBase(result);
    }
}