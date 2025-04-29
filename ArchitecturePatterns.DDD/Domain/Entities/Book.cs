using ArchitecturePatterns.DDD.Domain.ValueObjects;

namespace ArchitecturePatterns.DDD.Domain.Entities;

public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public ISBN Isbn { get; private set; }
    public bool IsBorrowed { get; private set; }

    public Book(Guid id, string title, ISBN isbn)
    {
        Id = id;
        Title = title;
        Isbn = isbn;
        IsBorrowed = false;
    }

    public void Borrow()
    {
        if (IsBorrowed) throw new InvalidOperationException("Book already borrowed.");
        IsBorrowed = true;
    }

    public void Return()
    {
        if (!IsBorrowed) throw new InvalidOperationException("Book was not borrowed.");
        IsBorrowed = false;
    }
}
