using ArchitecturePatterns.DDD.Domain.Entities;
using ArchitecturePatterns.DDD.Domain.Repositories;

namespace ArchitecturePatterns.DDD.Application.Services;

public class LibraryService
{
    private readonly IBookRepository _repository;

    public LibraryService(IBookRepository repository)
    {
        _repository = repository;
    }

    public void BorrowBook(Guid bookId)
    {
        var book = _repository.GetById(bookId) ?? throw new InvalidOperationException("Book not found.");
        book.Borrow();
    }

    public IEnumerable<Book> GetAvailableBooks()
    {
        return _repository.GetAll().Where(b => !b.IsBorrowed);
    }

    public void AddBook(Book book)
    {
        _repository.Add(book);
    }
}