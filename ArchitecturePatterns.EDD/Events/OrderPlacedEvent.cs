namespace ArchitecturePatterns.EDD.Events
{
    /// <summary>
    /// Represents an event that occurs when an order is placed in the system.
    /// This event is used to notify other components (e.g., inventory, shipping services) asynchronously in an Event-Driven Design (EDD) system.
    /// </summary>
    public class OrderPlacedEvent : IEvent
    {
        /// <summary>
        /// Gets the unique identifier for the order.
        /// This allows consumers of the event to identify which order was placed.
        /// </summary>
        public Guid OrderId { get; }

        /// <summary>
        /// Gets the name of the product being ordered.
        /// This helps to convey the context of the order, such as which product is involved.
        /// </summary>
        public string ProductName { get; }

        /// <summary>
        /// Gets the quantity of the product being ordered.
        /// This gives further context about the order details, such as how many units of the product were purchased.
        /// </summary>
        public int Quantity { get; }

        /// <summary>
        /// Gets the timestamp of when the event occurred.
        /// This is essential in Event-Driven Design (EDD) for ordering events correctly, replaying events, and maintaining consistency.
        /// </summary>
        public DateTime OccurredAt { get; } = DateTime.UtcNow;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderPlacedEvent"/> class.
        /// </summary>
        /// <param name="orderId">The unique identifier for the order.</param>
        /// <param name="productName">The name of the product being ordered.</param>
        /// <param name="quantity">The quantity of the product being ordered.</param>
        public OrderPlacedEvent(Guid orderId, string productName, int quantity)
        {
            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
        }
    }
}
