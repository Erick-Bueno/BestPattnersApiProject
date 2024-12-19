using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace projetassocavalo.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        var httpException = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        return Problem();
    }
}