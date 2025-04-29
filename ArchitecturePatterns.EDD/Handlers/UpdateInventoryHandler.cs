using ArchitecturePatterns.EDD.Events;

namespace ArchitecturePatterns.EDD.Handlers;

public class UpdateInventoryHandler : IEventHandler<OrderPlacedEvent>
{
    public Task HandleAsync(OrderPlacedEvent @event)
    {
        Console.WriteLine($"[Inventory] Deducted {@event.Quantity} units of '{@event.ProductName}'.");
        return Task.CompletedTask;
    }
}