using ArchitecturePatterns.DDD.Domain.Entities;
using ArchitecturePatterns.DDD.Domain.Repositories;

namespace ArchitecturePatterns.DDD.Infrastructure.Repositories;

/// <summary>
/// A simple in-memory implementation of the <see cref="IBookRepository"/> interface.
/// Used primarily for development, testing, or demonstration purposes where persistence is not required.
/// </summary>
public class InMemoryBookRepository : IBookRepository
{
    // Internal storage for books using a list as a stand-in for a database.
    private readonly List<Book> _books = new();

    /// <summary>
    /// Retrieves a book by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the book.</param>
    /// <returns>The <see cref="Book"/> if found; otherwise, <c>null</c>.</returns>
    public Book? GetById(Guid id) => _books.FirstOrDefault(b => b.Id == id);

    /// <summary>
    /// Adds a new book to the repository.
    /// </summary>
    /// <param name="book">The book to add.</param>
    public void Add(Book book) => _books.Add(book);

    /// <summary>
    /// Retrieves all books in the repository.
    /// </summary>
    /// <returns>An enumerable collection of all <see cref="Book"/> instances.</returns>
    public IEnumerable<Book> GetAll() => _books;
}
