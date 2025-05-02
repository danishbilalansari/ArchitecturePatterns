using ArchitecturePatterns.EDD.Events;

namespace ArchitecturePatterns.EDD.Handlers
{
    /// <summary>
    /// Represents a handler for processing events in an Event-Driven Design (EDD) system.
    /// The handler is responsible for reacting to a specific type of event and executing business logic based on it.
    /// </summary>
    /// <typeparam name="TEvent">The type of event that this handler processes. The event must implement the <see cref="IEvent"/> interface.</typeparam>
    public interface IEventHandler<TEvent> where TEvent : IEvent
    {
        /// <summary>
        /// Asynchronously handles the specified event.
        /// The event will be processed by the handler to trigger the necessary business logic.
        /// </summary>
        /// <param name="event">The event to be handled.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task HandleAsync(TEvent @event);
    }
}
