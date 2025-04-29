using ArchitecturePatterns.EDD.Events;
using ArchitecturePatterns.EDD.Infrastructure;

namespace ArchitecturePatterns.EDD.Services;

public class OrderService
{
    private readonly InMemoryEventBus _eventBus;

    public OrderService(InMemoryEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public async Task PlaceOrderAsync(string productName, int quantity)
    {
        var orderId = Guid.NewGuid();
        Console.WriteLine($"Order {orderId} placed for {quantity}x {productName}.");

        var orderEvent = new OrderPlacedEvent(orderId, productName, quantity);
        await _eventBus.PublishAsync(orderEvent);
    }
}