using ArchitecturePatterns.DDD.Application.Services;
using ArchitecturePatterns.DDD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ArchitecturePatterns.DDD.API.Controllers;

/// <summary>
/// Handles HTTP requests related to library operations in the DDD layer.
/// Provides endpoints for borrowing books and retrieving available books.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class LibraryController : ControllerBase
{
    private readonly LibraryService _service;

    /// <summary>
    /// Initializes a new instance of the <see cref="LibraryController"/> class with the specified service.
    /// </summary>
    /// <param name="service">An instance of the LibraryService handling business logic.</param>
    public LibraryController(LibraryService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retrieves a list of all available (not borrowed) books.
    /// </summary>
    /// <returns>A list of available <see cref="Book"/> entities.</returns>
    [HttpGet("available-books")]
    public ActionResult<IEnumerable<Book>> GetAvailableBooks()
    {
        var books = _service.GetAvailableBooks();
        return Ok(books);
    }

    /// <summary>
    /// Borrows a book with the specified ID.
    /// </summary>
    /// <param name="bookId">The ID of the book to borrow.</param>
    /// <returns>HTTP 200 OK if successful; otherwise, an appropriate error response.</returns>
    [HttpPost("borrow/{bookId}")]
    public IActionResult BorrowBook(Guid bookId)
    {
        _service.BorrowBook(bookId);
        return Ok();
    }
}
