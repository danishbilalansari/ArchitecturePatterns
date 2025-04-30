using ArchitecturePatterns.DDD.Application.Services;
using ArchitecturePatterns.DDD.Domain.Entities;
using ArchitecturePatterns.DDD.Domain.Entities.DTO;
using ArchitecturePatterns.DDD.Domain.ValueObjects;
using ArchitecturePatterns.DDD.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddSingleton<InMemoryBookRepository>();
builder.Services.AddSingleton<LibraryService>(sp =>
{
    var repo = sp.GetRequiredService<InMemoryBookRepository>();
    return new LibraryService(repo);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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

app.UseAuthorization();
app.MapControllers();
app.Run();
