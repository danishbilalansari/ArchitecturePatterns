using ArchitecturePatterns.EDD.Events;

namespace ArchitecturePatterns.EDD.Handlers;

public interface IEventHandler<TEvent> where TEvent : IEvent
{
    Task HandleAsync(TEvent @event);
}
