using ArchitecturePatterns.EDD.Events;
using ArchitecturePatterns.EDD.Handlers;

namespace ArchitecturePatterns.EDD.Infrastructure
{
    /// <summary>
    /// Represents an in-memory event bus that allows event handling and subscription.
    /// This class is used to manage event handlers and publish events to them.
    /// It serves as an example of a simple event bus implementation in an Event-Driven Design (EDD) system.
    /// </summary>
    public class InMemoryEventBus
    {
        // Dictionary to hold event handlers, mapped by event type.
        // Each event type (TEvent) has a list of handler functions to be invoked when an event is published.
        private readonly Dictionary<Type, List<Func<IEvent, Task>>> _handlers = new();

        /// <summary>
        /// Subscribes a handler to an event type.
        /// This method registers a handler to listen for specific events and process them when published.
        /// </summary>
        /// <typeparam name="TEvent">The type of event to subscribe to. The event must implement <see cref="IEvent"/>.</typeparam>
        /// <param name="handler">The handler that will process the event when it is published.</param>
        public void Subscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            // Ensure the event type has an entry in the handlers dictionary
            if (!_handlers.ContainsKey(typeof(TEvent)))
                _handlers[typeof(TEvent)] = new List<Func<IEvent, Task>>();

            // Add the handler to the list for this event type
            _handlers[typeof(TEvent)].Add(e => handler.HandleAsync((TEvent)e));
        }

        /// <summary>
        /// Publishes an event to all subscribed handlers.
        /// This method invokes the handler functions asynchronously for the event that is passed in.
        /// </summary>
        /// <param name="event">The event to be published to the subscribed handlers.</param>
        /// <returns>A task representing the asynchronous operation of publishing the event.</returns>
        public async Task PublishAsync(IEvent @event)
        {
            var eventType = @event.GetType();

            // Check if there are any handlers subscribed to the event type
            if (_handlers.ContainsKey(eventType))
            {
                var handlers = _handlers[eventType];
                // Execute each handler asynchronously for the event
                foreach (var handler in handlers)
                {
                    await handler(@event);
                }
            }
        }
    }
}
