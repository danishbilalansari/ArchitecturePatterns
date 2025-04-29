using ArchitecturePatterns.TDD.Models;

var builder = WebApplication.CreateBuilder(args);

// Enable Swagger (works with .NET 8+; .NET 9 once Swashbuckle updates)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger UI only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var calculator = new Calculator();

app.MapGet("/", () => "Calculator API running. Try /add?a=5&b=3");

// Calculator endpoints
app.MapGet("/add", (int a, int b) => Results.Ok(calculator.Add(a, b)));
app.MapGet("/subtract", (int a, int b) => Results.Ok(calculator.Subtract(a, b)));
app.MapGet("/multiply", (int a, int b) => Results.Ok(calculator.Multiply(a, b)));
app.MapGet("/divide", (int a, int b) =>
{
    try
    {
        return Results.Ok(calculator.Divide(a, b));
    }
    catch (DivideByZeroException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.Run();
