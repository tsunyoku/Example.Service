namespace Example.Api.Contracts.Responses;

public class GetAllCustomersResponse
{
    public required IEnumerable<CustomerResponse> Customers { get; init; }
}