using ArchitecturePatterns.EDD.Events;
using ArchitecturePatterns.EDD.Infrastructure;

namespace ArchitecturePatterns.EDD.Services
{
    /// <summary>
    /// Represents a service responsible for handling orders in an Event-Driven Design (EDD) system.
    /// The service places an order and publishes an event when the order is placed.
    /// </summary>
    public class OrderService
    {
        private readonly InMemoryEventBus _eventBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="eventBus">The event bus that will be used to publish events when an order is placed.</param>
        public OrderService(InMemoryEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        /// <summary>
        /// Places an order for a product and publishes an <see cref="OrderPlacedEvent"/>.
        /// This method generates a new order ID, logs the order placement, and triggers the event.
        /// </summary>
        /// <param name="productName">The name of the product being ordered.</param>
        /// <param name="quantity">The quantity of the product being ordered.</param>
        /// <returns>A task representing the asynchronous operation of placing the order and publishing the event.</returns>
        public async Task PlaceOrderAsync(string productName, int quantity)
        {
            // Generate a new order ID and log the order placement
            var orderId = Guid.NewGuid();
            Console.WriteLine($"Order {orderId} placed for {quantity} x {productName}.");

            // Create the OrderPlacedEvent
            var orderEvent = new OrderPlacedEvent(orderId, productName, quantity);

            // Publish the event to the event bus
            await _eventBus.PublishAsync(orderEvent);
        }
    }
}
