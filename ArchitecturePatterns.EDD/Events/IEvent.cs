namespace ArchitecturePatterns.EDD.Events
{
    // Interface representing an event in an Event-Driven Design (EDD) architecture.
    // Events in EDD serve as a mechanism for decoupling components by communicating state changes asynchronously.
    // The OccurredAt property captures the timestamp when the event was triggered, which is essential for:
    // 1. Event sequencing: Ordering events based on when they happened.
    // 2. Event replay: Replaying events in the same order they occurred to restore state.
    // 3. Event auditing: Tracking when significant changes occurred in the system.
    public interface IEvent
    {
        // The timestamp of when the event occurred.
        // In EDD, it's crucial for managing the event lifecycle (e.g., event ordering, replaying events).
        // It helps with maintaining consistency and temporal integrity in an event-driven system.
        DateTime OccurredAt { get; }
    }
}
