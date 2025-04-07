using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace GazpromTestProject.Core.Models.Companies;

public class MailingAddress: ValueObject
{
    public string Street { get; }
    public string City { get; }
    public string PostalCode { get; }
    
    private MailingAddress(string street, string city, string postalCode)
    {
        Street = street;
        City = city;
        PostalCode = postalCode;
    }
    
    public static Result<MailingAddress> Create(string street, string city, string postalCode)
    {
        if (string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(city))
            return Result.Failure<MailingAddress>("Street, city, and region must not be empty.");

        // Проверка почтового индекса (например, для России 5 цифр)
        var postalCodeRegex = new Regex(@"^\d{5}$", RegexOptions.Compiled);
        if (!postalCodeRegex.IsMatch(postalCode))
            return Result.Failure<MailingAddress>("Postal code format is invalid. It must be 5 digits.");

        return Result.Success(new MailingAddress(street, city, postalCode));
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}