namespace ArchitecturePatterns.DDD.Domain.ValueObjects;

public record ISBN
{
    public string Value { get; }

    public ISBN(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length != 13)
        {
            throw new ArgumentException("ISBN must be 13 characters long.", nameof(value));
        }

        Value = value;
    }

    public override string ToString() => Value;
}
