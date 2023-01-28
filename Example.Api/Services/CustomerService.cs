using Example.Api.Contracts.Messages;
using Example.Api.Domain;
using Example.Api.Mapping;
using Example.Api.Messaging;
using Example.Api.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace Example.Api.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ISnsMessenger _snsMessenger;
    
    public CustomerService(ICustomerRepository customerRepository, ISnsMessenger snsMessenger)
    {
        _customerRepository = customerRepository;
        _snsMessenger = snsMessenger;
    }
    
    public async Task<bool> CreateAsync(Customer customer)
    {
        var existingUser = await _customerRepository.GetAsync(customer.Id);
        if (existingUser is not null)
        {
            var message = $"A user with id {customer.Id} already exists";
            throw new ValidationException(message, GenerateValidationError(nameof(Customer), message));
        }

        existingUser = await _customerRepository.GetByUsernameAsync(customer.Username);
        if (existingUser is not null)
        {
            var message = $"A user with username {customer.Username} already exists";
            throw new ValidationException(message, GenerateValidationError(nameof(Customer), message));
        }

        var customerDto = customer.ToCustomerDto();
        var response = await _customerRepository.CreateAsync(customerDto);
        if (response)
            await _snsMessenger.PublishMessageAsync(customer.ToCustomerCreatedMessage());

        return response;
    }
    
    public async Task<Customer?> GetAsync(Guid id)
    {
        var customerDto = await _customerRepository.GetAsync(id);
        return customerDto?.ToCustomer();
    }

    public async Task<Customer?> GetByUsernameAsync(string username)
    {
        var customerDto = await _customerRepository.GetByUsernameAsync(username);
        return customerDto?.ToCustomer();
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        var customerDtos = await _customerRepository.GetAllAsync();
        return customerDtos.Select(x => x.ToCustomer());
    }

    public async Task<bool> UpdateAsync(Customer customer)
    {
        var customerDto = customer.ToCustomerDto();

        var response = await _customerRepository.UpdateAsync(customerDto, requestStarted: DateTime.Now);
        if (response)
            await _snsMessenger.PublishMessageAsync(customer.ToCustomerUpdatedMessage());

        return response;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var response = await _customerRepository.DeleteAsync(id);
        if (response)
        {
            await _snsMessenger.PublishMessageAsync(new CustomerDeleted
            {
                Id = id
            });
        }

        return response;
    }
    
    private static IEnumerable<ValidationFailure> GenerateValidationError(string paramName, string message)
    {
        return new []
        {
            new ValidationFailure(paramName, message)
        };
    }
}