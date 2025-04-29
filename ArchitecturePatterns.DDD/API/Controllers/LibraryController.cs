using ArchitecturePatterns.DDD.Application.Services;
using ArchitecturePatterns.DDD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ArchitecturePatterns.DDD.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibraryController : ControllerBase
{
    private readonly LibraryService _service;

    public LibraryController(LibraryService service)
    {
        _service = service;
    }

    [HttpGet("available-books")]
    public ActionResult<IEnumerable<Book>> GetAvailableBooks()
    {
        var books = _service.GetAvailableBooks();
        return Ok(books);
    }

    [HttpPost("borrow/{bookId}")]
    public IActionResult BorrowBook(Guid bookId)
    {
        _service.BorrowBook(bookId);
        return Ok();
    }
}