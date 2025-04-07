using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace GazpromTestProject.Core.Models.Users;

public class Email: ValueObject
{
    public string EmailValue { get; }
    
    private Email(string email)
    {
        EmailValue = email;
    }
    
    public static Result<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return Result.Failure<Email>("Email cannot be empty");
        
        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        if (!emailRegex.IsMatch(email))
            return Result.Failure<Email>("Email format is invalid.");
        
        return Result.Success(new Email(email));
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}