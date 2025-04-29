using ArchitecturePatterns.EDD.Handlers;
using ArchitecturePatterns.EDD.Infrastructure;
using ArchitecturePatterns.EDD.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setup Event Bus
var eventBus = new InMemoryEventBus();
var emailHandler = new SendEmailHandler();
var inventoryHandler = new UpdateInventoryHandler();

eventBus.Subscribe(emailHandler);
eventBus.Subscribe(inventoryHandler);

builder.Services.AddSingleton(eventBus);
builder.Services.AddScoped<OrderService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
