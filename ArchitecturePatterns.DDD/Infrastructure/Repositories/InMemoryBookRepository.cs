using ArchitecturePatterns.DDD.Domain.Entities;
using ArchitecturePatterns.DDD.Domain.Repositories;

namespace ArchitecturePatterns.DDD.Infrastructure.Repositories;

public class InMemoryBookRepository : IBookRepository
{
    private readonly List<Book> _books = new();

    public Book? GetById(Guid id) => _books.FirstOrDefault(b => b.Id == id);

    public void Add(Book book) => _books.Add(book);

    public IEnumerable<Book> GetAll() => _books;
}