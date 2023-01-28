using Example.Api.Contracts.Data;
using Example.Api.Domain;

namespace Example.Api.Mapping;

public static class DomainToDtoMapper
{
    public static CustomerDto ToCustomerDto(this Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id,
            Username = customer.Username,
            Email = customer.Email,
            DateOfBirth = customer.DateOfBirth
        };
    }
}