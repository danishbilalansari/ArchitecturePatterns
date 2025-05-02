using ArchitecturePatterns.DDD.Domain.Entities;
using ArchitecturePatterns.DDD.Domain.Repositories;

namespace ArchitecturePatterns.DDD.Application.Services;

/// <summary>
/// Provides application-level operations related to library functionality.
/// Encapsulates use cases such as borrowing books, listing available books, and adding new books.
/// </summary>
public class LibraryService
{
    private readonly IBookRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="LibraryService"/> class.
    /// </summary>
    /// <param name="repository">The book repository for data persistence and retrieval.</param>
    public LibraryService(IBookRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Borrows a book by its unique identifier.
    /// </summary>
    /// <param name="bookId">The unique identifier of the book to borrow.</param>
    /// <exception cref="InvalidOperationException">Thrown if the book is not found or already borrowed.</exception>
    public void BorrowBook(Guid bookId)
    {
        var book = _repository.GetById(bookId)
                   ?? throw new InvalidOperationException("Book not found.");
        book.Borrow();
    }

    /// <summary>
    /// Retrieves all books that are currently available (not borrowed).
    /// </summary>
    /// <returns>An enumerable collection of available books.</returns>
    public IEnumerable<Book> GetAvailableBooks()
    {
        return _repository.GetAll().Where(b => !b.IsBorrowed);
    }

    /// <summary>
    /// Adds a new book to the library collection.
    /// </summary>
    /// <param name="book">The <see cref="Book"/> entity to be added.</param>
    public void AddBook(Book book)
    {
        _repository.Add(book);
    }
}
