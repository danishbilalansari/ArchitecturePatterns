using ArchitecturePatterns.DDD.Application.Services;
using ArchitecturePatterns.DDD.Domain.Entities;
using ArchitecturePatterns.DDD.Domain.Entities.DTO;
using ArchitecturePatterns.DDD.Domain.ValueObjects;
using ArchitecturePatterns.DDD.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Configures services and middleware for the DDD-based API application.
/// </summary>

// Adds MVC-style controller support
builder.Services.AddControllers();

// Enables Swagger/OpenAPI for API documentation and testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// <summary>
/// Dependency Injection setup for the in-memory repository and LibraryService.
/// </summary>
builder.Services.AddSingleton<InMemoryBookRepository>();
builder.Services.AddSingleton<LibraryService>(sp =>
{
    var repo = sp.GetRequiredService<InMemoryBookRepository>();
    return new LibraryService(repo);
});

var app = builder.Build();

// Enable Swagger UI only in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/// <summary>
/// HTTP POST endpoint to add a book to the library using a BookDTO.
/// Converts DTO to domain model and validates ISBN before persisting.
/// </summary>
app.MapPost("/library/books", (BookDTO dto, LibraryService service) =>
{
    try
    {
        var isbn = new ISBN(dto.ISBN);
        var book = new Book(dto.Id, dto.Title, isbn);
        service.AddBook(book);
        return Results.Created($"/library/books/{dto.Id}", book);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { Message = ex.Message });
    }
});

// Enables authorization middleware (placeholder - can be extended)
app.UseAuthorization();

// Maps controller endpoints
app.MapControllers();

// Starts the web application
app.Run();
