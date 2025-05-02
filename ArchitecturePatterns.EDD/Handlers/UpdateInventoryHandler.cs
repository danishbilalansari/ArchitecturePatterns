using ArchitecturePatterns.EDD.Events;

namespace ArchitecturePatterns.EDD.Handlers
{
    /// <summary>
    /// Handles the <see cref="OrderPlacedEvent"/> by updating the inventory.
    /// This class implements the <see cref="IEventHandler{TEvent}"/> interface for the <see cref="OrderPlacedEvent"/>
    /// and contains the logic to process the event and update the inventory.
    /// </summary>
    public class UpdateInventoryHandler : IEventHandler<OrderPlacedEvent>
    {
        /// <summary>
        /// Asynchronously handles the <see cref="OrderPlacedEvent"/> by updating the inventory.
        /// This method simulates the deduction of ordered product quantities from the inventory.
        /// In a real-world scenario, this could involve updating a database or an inventory management system.
        /// </summary>
        /// <param name="event">The <see cref="OrderPlacedEvent"/> containing the order details.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task HandleAsync(OrderPlacedEvent @event)
        {
            // Simulating inventory update by printing to the console
            Console.WriteLine($"[Inventory] Deducted {@event.Quantity} units of '{@event.ProductName}'.");
            return Task.CompletedTask; // In a real-world scenario, database updates would occur here
        }
    }
}
