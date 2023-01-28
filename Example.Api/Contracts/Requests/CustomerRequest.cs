namespace Example.Api.Contracts.Requests;

public class CustomerRequest
{
    public string Username { get; init; } = default!;
    public string Email { get; init; } = default!;
    public DateTime DateOfBirth { get; init; } = default!;
}