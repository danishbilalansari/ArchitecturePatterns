using ArchitecturePatterns.EDD.Events;
using ArchitecturePatterns.EDD.Handlers;

namespace ArchitecturePatterns.EDD.Infrastructure;

public class InMemoryEventBus
{
    private readonly Dictionary<Type, List<Func<IEvent, Task>>> _handlers = new();

    public void Subscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent
    {
        if (!_handlers.ContainsKey(typeof(TEvent)))
            _handlers[typeof(TEvent)] = new List<Func<IEvent, Task>>();

        _handlers[typeof(TEvent)].Add(e => handler.HandleAsync((TEvent)e));
    }

    public async Task PublishAsync(IEvent @event)
    {
        var eventType = @event.GetType();
        if (_handlers.ContainsKey(eventType))
        {
            var handlers = _handlers[eventType];
            foreach (var handler in handlers)
            {
                await handler(@event);
            }
        }
    }
}