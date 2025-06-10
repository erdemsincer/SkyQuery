using MediatR;
using SkyQuery.Auth.Application.Auth.Commands;
using SkyQuery.Auth.Application.Auth.Interfaces;
using SkyQuery.Auth.Application.Common.Interfaces;
using SkyQuery.Auth.Contracts.Responses;

namespace SkyQuery.Auth.Application.Auth.Handlers;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginUserHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid credentials.");

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new LoginUserResponse(user.Id, user.Email, token);
    }
}
