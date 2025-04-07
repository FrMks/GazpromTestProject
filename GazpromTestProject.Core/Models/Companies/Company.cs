using CSharpFunctionalExtensions;
using GazpromTestProject.Core.Models.Users;

namespace GazpromTestProject.Core.Models.Companies;

public class Company: Entity
{
    public string Name { get; set; } = string.Empty;
    public MailingAddress MailingAddress = null!;

    private readonly List<User> _users = new();
    public IReadOnlyCollection<User> Users => _users.AsReadOnly();

    private Company() { }

    public Company(string name, MailingAddress mailingAddress)
    {
        Name = name;
        MailingAddress = mailingAddress;
    }
}