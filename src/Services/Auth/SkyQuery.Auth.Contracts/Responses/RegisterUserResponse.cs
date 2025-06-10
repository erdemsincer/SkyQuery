namespace SkyQuery.Auth.Contracts.Responses;

public record RegisterUserResponse(Guid Id, string Email, string Token);
