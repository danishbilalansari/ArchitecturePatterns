using ArchitecturePatterns.DDD.Domain.Entities;

namespace ArchitecturePatterns.DDD.Domain.Repositories;

/// <summary>
/// Defines a contract for interacting with the data source for <see cref="Book"/> entities.
/// </summary>
public interface IBookRepository
{
    /// <summary>
    /// Retrieves a book by its unique identifier.
    /// </summary>
    /// <param name="id">The unique ID of the book.</param>
    /// <returns>The matching <see cref="Book"/> if found; otherwise, <c>null</c>.</returns>
    Book? GetById(Guid id);

    /// <summary>
    /// Adds a new book to the repository.
    /// </summary>
    /// <param name="book">The <see cref="Book"/> to add.</param>
    void Add(Book book);

    /// <summary>
    /// Retrieves all books from the repository.
    /// </summary>
    /// <returns>A collection of all <see cref="Book"/> entities.</returns>
    IEnumerable<Book> GetAll();
}
