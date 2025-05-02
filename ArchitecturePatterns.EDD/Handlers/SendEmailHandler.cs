using ArchitecturePatterns.EDD.Events;

namespace ArchitecturePatterns.EDD.Handlers
{
    /// <summary>
    /// Handles the <see cref="OrderPlacedEvent"/> by sending an email confirmation.
    /// This class implements the <see cref="IEventHandler{TEvent}"/> interface for the <see cref="OrderPlacedEvent"/>
    /// and contains the logic to handle the event asynchronously.
    /// </summary>
    public class SendEmailHandler : IEventHandler<OrderPlacedEvent>
    {
        /// <summary>
        /// Asynchronously handles the <see cref="OrderPlacedEvent"/> by sending an email confirmation.
        /// This method simulates sending a confirmation email when an order is placed.
        /// In a real-world scenario, this could involve calling an email service API.
        /// </summary>
        /// <param name="event">The <see cref="OrderPlacedEvent"/> containing the order details.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task HandleAsync(OrderPlacedEvent @event)
        {
            // Simulating sending an email
            Console.WriteLine($"[Email] Sent confirmation for Order {@event.OrderId}.");
            return Task.CompletedTask; // In a real-world case, you might use an actual email service here
        }
    }
}
