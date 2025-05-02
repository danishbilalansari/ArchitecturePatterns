namespace ArchitecturePatterns.DDD.Domain.Entities.DTO;

/// <summary>
/// Represents a Data Transfer Object (DTO) for transferring book data 
/// outside the domain (e.g., to the UI layer or API response).
/// </summary>
/// <param name="Id">The unique identifier of the book.</param>
/// <param name="Title">The title of the book.</param>
/// <param name="ISBN">The ISBN of the book represented as a string.</param>
public record BookDTO(Guid Id, string Title, string ISBN);
