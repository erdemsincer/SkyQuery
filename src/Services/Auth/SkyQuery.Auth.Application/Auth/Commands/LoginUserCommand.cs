using MediatR;
using SkyQuery.Auth.Contracts.Responses;

namespace SkyQuery.Auth.Application.Auth.Commands;

public record LoginUserCommand(string Email, string Password) : IRequest<LoginUserResponse>;
