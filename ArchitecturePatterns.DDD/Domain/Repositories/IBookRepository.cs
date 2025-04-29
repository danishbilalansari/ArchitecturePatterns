using ArchitecturePatterns.DDD.Domain.Entities;

namespace ArchitecturePatterns.DDD.Domain.Repositories;

public interface IBookRepository
{
    Book? GetById(Guid id);
    void Add(Book book);
    IEnumerable<Book> GetAll();
}