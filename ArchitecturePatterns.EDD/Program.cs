using ArchitecturePatterns.EDD.Handlers;
using ArchitecturePatterns.EDD.Infrastructure;
using ArchitecturePatterns.EDD.Services;

var builder = WebApplication.CreateBuilder(args);

// Register controllers for API functionality
builder.Services.AddControllers();

// Register services for Swagger UI to expose API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setup Event Bus
var eventBus = new InMemoryEventBus(); // In-memory event bus for managing event subscriptions
var emailHandler = new SendEmailHandler(); // Event handler for sending email confirmations
var inventoryHandler = new UpdateInventoryHandler(); // Event handler for updating inventory

// Subscribe handlers to the event bus for OrderPlacedEvent
eventBus.Subscribe(emailHandler); // Subscribe email handler to handle the OrderPlacedEvent
eventBus.Subscribe(inventoryHandler); // Subscribe inventory handler to handle the OrderPlacedEvent

// Register services for dependency injection
builder.Services.AddSingleton(eventBus); // Register event bus as a singleton
builder.Services.AddScoped<OrderService>(); // Register OrderService with a scoped lifetime

var app = builder.Build();

// Configure middleware and API settings
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development environment
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use authorization middleware
app.UseAuthorization();

// Map controllers for the API
app.MapControllers();

// Run the application
app.Run();
