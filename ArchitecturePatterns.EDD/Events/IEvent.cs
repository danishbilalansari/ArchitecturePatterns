namespace ArchitecturePatterns.EDD.Events;

public interface IEvent
{
    DateTime OccurredAt { get; }
}