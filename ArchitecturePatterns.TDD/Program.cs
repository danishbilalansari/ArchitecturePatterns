using ArchitecturePatterns.TDD.Models;

var builder = WebApplication.CreateBuilder(args);

// Enable Swagger for API documentation (works with .NET 8+; .NET 9 once Swashbuckle updates)
builder.Services.AddEndpointsApiExplorer(); // Adds endpoint metadata for API exploration
builder.Services.AddSwaggerGen(); // Adds Swagger support for API documentation

var app = builder.Build();

// Configure Swagger UI only in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enables Swagger middleware to generate the API documentation
    app.UseSwaggerUI(); // Provides an interactive Swagger UI for testing endpoints
}

// Create an instance of the Calculator class (this could be injected in more complex scenarios)
var calculator = new Calculator();

// Basic route for root to indicate the API is running
app.MapGet("/", () => "Calculator API running. Try /add?a=5&b=3");

/// <summary>
/// Endpoint for addition of two integers.
/// </summary>
/// <param name="a">The first integer to add.</param>
/// <param name="b">The second integer to add.</param>
/// <returns>The sum of the two integers.</returns>
app.MapGet("/add", (int a, int b) => Results.Ok(calculator.Add(a, b)));

/// <summary>
/// Endpoint for subtraction of two integers.
/// </summary>
/// <param name="a">The integer to subtract from.</param>
/// <param name="b">The integer to subtract.</param>
/// <returns>The difference of the two integers.</returns>
app.MapGet("/subtract", (int a, int b) => Results.Ok(calculator.Subtract(a, b)));

/// <summary>
/// Endpoint for multiplication of two integers.
/// </summary>
/// <param name="a">The first integer to multiply.</param>
/// <param name="b">The second integer to multiply.</param>
/// <returns>The product of the two integers.</returns>
app.MapGet("/multiply", (int a, int b) => Results.Ok(calculator.Multiply(a, b)));

/// <summary>
/// Endpoint for division of two integers.
/// Returns a BadRequest response if division by zero is attempted.
/// </summary>
/// <param name="a">The integer to divide.</param>
/// <param name="b">The integer to divide by.</param>
/// <returns>The quotient of the two integers, or a BadRequest response if division by zero occurs.</returns>
app.MapGet("/divide", (int a, int b) =>
{
    try
    {
        return Results.Ok(calculator.Divide(a, b)); // Returns the result of the division
    }
    catch (DivideByZeroException ex)
    {
        return Results.BadRequest(ex.Message); // Returns BadRequest with the error message when dividing by zero
    }
});

// Run the web application
app.Run();
