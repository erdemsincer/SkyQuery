using MediatR;
using SkyQuery.Auth.Application.Auth.Commands;
using SkyQuery.Auth.Application.Auth.Interfaces;
using SkyQuery.Auth.Application.Common.Interfaces;
using SkyQuery.Auth.Contracts.Responses;
using SkyQuery.Auth.Domain.Entities;

namespace SkyQuery.Auth.Application.Auth.Handlers;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterUserHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.ExistsByEmailAsync(request.Email))
            throw new Exception("Email already in use.");

        var user = new User(request.Email, BCrypt.Net.BCrypt.HashPassword(request.Password));
        await _userRepository.AddAsync(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new RegisterUserResponse(user.Id, user.Email, token);
    }
}
