using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace GazpromTestProject.Core.Models.Users;

public class PhoneNumber: ValueObject
{
    public string PhoneNumberValue { get; set; }

    private PhoneNumber(string phoneNumberValue)
    {
        PhoneNumberValue = phoneNumberValue;
    }

    public static Result<PhoneNumber> Create(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return Result.Failure<PhoneNumber>("Phone number cannot be empty");
        
        var phoneRegex = new Regex(@"^(\+7|7|8)?\(?\d{3}\)?\d{3}-?\d{2}-?\d{2}$", RegexOptions.Compiled);

        if (!phoneRegex.IsMatch(phoneNumber)) 
            return Result.Failure<PhoneNumber>("Phone number is not valid");

        return Result.Success(new PhoneNumber(phoneNumber));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PhoneNumberValue;
    }
}