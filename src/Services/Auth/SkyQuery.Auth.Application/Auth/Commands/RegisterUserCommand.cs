using MediatR;
using SkyQuery.Auth.Contracts.Responses;

namespace SkyQuery.Auth.Application.Auth.Commands;

public record RegisterUserCommand(string Email, string Password) : IRequest<RegisterUserResponse>;
