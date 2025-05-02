using ArchitecturePatterns.DDD.Domain.ValueObjects;

namespace ArchitecturePatterns.DDD.Domain.Entities;

/// <summary>
/// Represents a Book entity in the domain model.
/// Contains behavior and rules related to borrowing and returning books.
/// </summary>
public class Book
{
    /// <summary>
    /// Gets the unique identifier of the book.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets the title of the book.
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Gets the ISBN value object of the book.
    /// </summary>
    public ISBN Isbn { get; private set; }

    /// <summary>
    /// Indicates whether the book is currently borrowed.
    /// </summary>
    public bool IsBorrowed { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Book"/> class with the specified id, title, and ISBN.
    /// </summary>
    /// <param name="id">The unique identifier of the book.</param>
    /// <param name="title">The title of the book.</param>
    /// <param name="isbn">The ISBN value object of the book.</param>
    public Book(Guid id, string title, ISBN isbn)
    {
        Id = id;
        Title = title;
        Isbn = isbn;
        IsBorrowed = false;
    }

    /// <summary>
    /// Marks the book as borrowed. Throws an exception if it's already borrowed.
    /// </summary>
    public void Borrow()
    {
        if (IsBorrowed)
            throw new InvalidOperationException("Book already borrowed.");
        IsBorrowed = true;
    }

    /// <summary>
    /// Marks the book as returned. Throws an exception if it was not borrowed.
    /// </summary>
    public void Return()
    {
        if (!IsBorrowed)
            throw new InvalidOperationException("Book was not borrowed.");
        IsBorrowed = false;
    }
}
