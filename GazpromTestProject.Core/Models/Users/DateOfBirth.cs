using CSharpFunctionalExtensions;

namespace GazpromTestProject.Core.Models.Users;

public class DateOfBirth: ValueObject
{
    public DateTime Value { get; }

    private DateOfBirth(DateTime value)
    {
        Value = value.Date; 
    }

    public static Result<DateOfBirth> Create(DateTime date)
    {
        if (date > DateTime.UtcNow)
            return Result.Failure<DateOfBirth>("Date cannot be in the future.");
        
        var today = DateTime.UtcNow.Date;
        int age = today.Year - date.Year;
        if (date.Date > today.AddYears(-age)) 
            age--;
        if (age < 18)
            return Result.Failure<DateOfBirth>("User must be at least 18 years old.");

        return Result.Success(new DateOfBirth(date));
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
}