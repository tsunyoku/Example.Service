namespace Example.Api.Contracts.Responses;

public class CustomerResponse
{
    public required Guid Id { get; init; }
    public required string Username { get; init; }
    public required string Email { get; init; }
    public required DateTime DateOfBirth { get; init; }
}