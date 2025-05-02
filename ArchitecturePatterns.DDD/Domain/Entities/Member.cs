namespace ArchitecturePatterns.DDD.Domain.Entities;

/// <summary>
/// Represents a library member in the domain.
/// </summary>
public class Member
{
    /// <summary>
    /// Gets the unique identifier of the member.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets the name of the member.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Member"/> class with the specified ID and name.
    /// </summary>
    /// <param name="id">The unique identifier of the member.</param>
    /// <param name="name">The full name of the member.</param>
    public Member(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
