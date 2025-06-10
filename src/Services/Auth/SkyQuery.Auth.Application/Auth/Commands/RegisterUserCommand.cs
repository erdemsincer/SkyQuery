using MediatR;

namespace SkyQuery.Auth.Application.Auth.Commands
{
    // SkyQuery.Auth.Application/Auth/Commands/RegisterUserCommand.cs
    public record RegisterUserCommand(string Email, string Password) : IRequest<Result<Guid>>;

}
