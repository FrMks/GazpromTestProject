using CSharpFunctionalExtensions;
using GazpromTestProject.Core.Models.Companies;

namespace GazpromTestProject.Core.Models.Users;

public class User: Entity
{
    public Name Name { get; set; } = null!;
    public DateOfBirth DateOfBirth { get; set; } = null!;
    public Email Email { get; set; } = null!;
    public PhoneNumber PhoneNumber { get; set; } = null!;
    
    public Company Company { get; set; } = null!;
    
    private readonly List<Skill> _skills = new();
    public IReadOnlyCollection<Skill> Skills => _skills.AsReadOnly();

    private User() { }

    public User(Name name, DateOfBirth dateOfBirth, Email email, PhoneNumber phoneNumber, Company company)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        Email = email;
        PhoneNumber = phoneNumber;
        Company = company ?? throw new ArgumentNullException(nameof(company));
    }
}