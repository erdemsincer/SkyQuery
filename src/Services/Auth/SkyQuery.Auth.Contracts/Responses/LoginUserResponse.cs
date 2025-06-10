namespace SkyQuery.Auth.Contracts.Responses;

public record LoginUserResponse(Guid Id, string Email, string Token);
