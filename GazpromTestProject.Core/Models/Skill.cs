using CSharpFunctionalExtensions;
using GazpromTestProject.Core.Models.Users;

namespace GazpromTestProject.Core.Models;

public class Skill: Entity
{
    public string Name { get; set; }
    
    private readonly List<User> _users = new();
    public IReadOnlyCollection<User> Users => _users.AsReadOnly();

    private Skill() { }

    public Skill(string name)
    {
        Name = name;
    }
}