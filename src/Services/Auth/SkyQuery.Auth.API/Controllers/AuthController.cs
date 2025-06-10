using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyQuery.Auth.Application.Auth.Commands;
using SkyQuery.Auth.Contracts.Requests;
using SkyQuery.Auth.Contracts.Responses;

namespace SkyQuery.Auth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator) => _mediator = mediator;

    [HttpPost("register")]
    public async Task<ActionResult<RegisterUserResponse>> Register(RegisterUserRequest request)
    {
        var command = new RegisterUserCommand(request.Email, request.Password);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPost("login")]
    public async Task<ActionResult<LoginUserResponse>> Login(LoginUserRequest request)
    {
        var command = new LoginUserCommand(request.Email, request.Password);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

}
