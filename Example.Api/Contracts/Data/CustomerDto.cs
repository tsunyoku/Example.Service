using System.Text.Json.Serialization;

namespace Example.Api.Contracts.Data;

public class CustomerDto
{
    [JsonPropertyName("pk")]
    public string Pk => Id.ToString();

    [JsonPropertyName("sk")]
    public string Sk => Id.ToString();
    
    public required Guid Id { get; init; }
    public required string Username { get; init; }
    public required string Email { get; init; }
    public required DateTime DateOfBirth { get; init; }

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}