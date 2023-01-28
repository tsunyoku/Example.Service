using Example.Api.Contracts.Data;
using Example.Api.Domain;

namespace Example.Api.Mapping;

public static class DtoToDomainMapper
{
    public static Customer ToCustomer(this CustomerDto customerDto)
    {
        return new Customer
        {
            Id = customerDto.Id,
            Username = customerDto.Username,
            Email = customerDto.Email,
            DateOfBirth = customerDto.DateOfBirth
        };
    }
}