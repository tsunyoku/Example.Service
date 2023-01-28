using Example.Api.Contracts.Requests;
using Example.Api.Domain;

namespace Example.Api.Mapping;

public static class ApiContractToDomainMapper
{
    public static Customer ToCustomer(this CustomerRequest request)
    {
        return new Customer
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth
        };
    }

    public static Customer ToCustomer(this UpdateCustomerRequest request)
    {
        return new Customer
        {
            Id = request.Id,
            Username = request.Customer.Username,
            Email = request.Customer.Email,
            DateOfBirth = request.Customer.DateOfBirth
        };
    }
}