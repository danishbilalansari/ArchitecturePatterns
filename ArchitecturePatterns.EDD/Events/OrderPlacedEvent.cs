namespace ArchitecturePatterns.EDD.Events;

public class OrderPlacedEvent : IEvent
{
    public Guid OrderId { get; }
    public string ProductName { get; }
    public int Quantity { get; }
    public DateTime OccurredAt { get; } = DateTime.UtcNow;

    public OrderPlacedEvent(Guid orderId, string productName, int quantity)
    {
        OrderId = orderId;
        ProductName = productName;
        Quantity = quantity;
    }
}
