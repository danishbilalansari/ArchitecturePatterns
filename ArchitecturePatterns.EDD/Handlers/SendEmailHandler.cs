using ArchitecturePatterns.EDD.Events;

namespace ArchitecturePatterns.EDD.Handlers;

public class SendEmailHandler : IEventHandler<OrderPlacedEvent>
{
    public Task HandleAsync(OrderPlacedEvent @event)
    {
        Console.WriteLine($"[Email] Sent confirmation for Order {@event.OrderId}.");
        return Task.CompletedTask;
    }
}