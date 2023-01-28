using System.Text.RegularExpressions;
using Example.Api.Contracts.Requests;
using FluentValidation;

namespace Example.Api.Validation;

public partial class CustomerRequestValidator : AbstractValidator<CustomerRequest>
{
    public CustomerRequestValidator()
    {
        RuleFor(x => x.Username)
            .Matches(UsernameRegex());
        
        RuleFor(x => x.Email)
            .EmailAddress();

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Now)
            .WithMessage("Date of birth cannot be in the future");
    }
    
    [GeneratedRegex("^[a-z\\d](?:[a-z\\d]|-(?=[a-z\\d])){0,38}$", RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-GB")]
    private static partial Regex UsernameRegex();
}