using Example.Api.Contracts.Messages;
using Example.Api.Domain;

namespace Example.Api.Mapping;

public static class DomainToMessageMapper
{
    public static CustomerCreated ToCustomerCreatedMessage(this Customer customer)
    {
        return new CustomerCreated
        {
            Id = customer.Id,
            Username = customer.Username,
            Email = customer.Email,
            DateOfBirth = customer.DateOfBirth
        };
    }

    public static CustomerUpdated ToCustomerUpdatedMessage(this Customer customer)
    {
        return new CustomerUpdated
        {
            Id = customer.Id,
            Username = customer.Username,
            Email = customer.Email,
            DateOfBirth = customer.DateOfBirth
        };
    }
}