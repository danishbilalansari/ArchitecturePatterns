namespace ArchitecturePatterns.DDD.Domain.ValueObjects;

/// <summary>
/// Represents the value object for an International Standard Book Number (ISBN).
/// </summary>
public record ISBN
{
    /// <summary>
    /// The 13-character string value of the ISBN.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ISBN"/> record.
    /// </summary>
    /// <param name="value">The 13-character ISBN value.</param>
    /// <exception cref="ArgumentNullException">Thrown when the value is null or whitespace.</exception>
    /// <exception cref="ArgumentException">Thrown when the value is not exactly 13 characters long.</exception>
    public ISBN(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value), "ISBN value cannot be null or empty.");
        }

        if (value.Length != 13)
        {
            throw new ArgumentException("ISBN must be 13 characters long.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// Returns the string representation of the ISBN.
    /// </summary>
    /// <returns>The string value of the ISBN.</returns>
    public override string ToString() => Value;
}
