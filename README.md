# Architecture Patterns (.NET 9)

This project demonstrates three distinct software design paradigms implemented in .NET 9 using Minimal APIs:

### Domain-Driven Design (DDD)

> Focus: **Modeling complex business domains**

**DDD** emphasizes creating software that reflects real-world business logic through a rich domain model. It promotes a close alignment between domain experts and developers.

**Key Concepts:**
- Entities, Value Objects, and Aggregates
- Domain Services encapsulate business logic
- Ubiquitous Language shared between tech and business
- Repositories abstract persistence
- Bounded Contexts to isolate domain concerns

**When to Use:**
- Complex business domains (e.g., banking, logistics)
- Need for deep domain modeling and collaboration


### Event-Driven Design (EDD)

> Focus: **Decoupled, reactive systems via events**

**EDD** structures your application around events that represent meaningful business actions. It's well-suited for distributed systems and services that need to react asynchronously.

**Key Concepts:**
- Events represent state changes (e.g., `OrderPlaced`)
- Event Publishers and Subscribers
- Loose coupling between components
- Ideal for microservices, CQRS, and message queues

**When to Use:**
- Real-time updates or workflows
- Systems with asynchronous processing or integrations

### Test-Driven Development (TDD)

> Focus: **Quality-first development via tests**

**TDD** is a programming methodology where tests are written before the code that satisfies them. It helps ensure correctness, drive design, and improve maintainability.

**Key Concepts:**
- Red → Green → Refactor cycle
- Write a failing test, then write code to pass it
- Encourages small, focused functions and better design

**When to Use:**
- Applications where stability and refactoring are frequent
- Codebases that benefit from high test coverage

## Side-by-Side Comparison

| Principle | DDD                           | EDD                             | TDD                            |
|----------|-------------------------------|----------------------------------|--------------------------------|
| Focus    | Business domain modeling      | Decoupled, event-based flow     | Code correctness via testing  |
| Key Unit | Entity / Aggregate Root       | Event / Message                 | Test case                     |
| Benefits | Business alignment, clarity   | Scalability, async processing   | High code confidence          |
| Use Case | Business-heavy applications   | Realtime/messaging systems      | Any app needing reliability   |

## Projects in This Solution (Demo)

| Project                    | Pattern                | Description |
|----------------------------|------------------------|-------------|
| `ArchitecturePatterns.DDD` | Domain-Driven Design   | A Book Library system with rich domain models (e.g., `Book`, `ISBN`) and domain services. |
| `ArchitecturePatterns.EDD` | Event-Driven Design    | An Order Placement system publishing events (email, inventory, audit). |
| `ArchitecturePatterns.TDD` | Test-Driven Development| A simple Calculator with full unit test coverage and a minimal API surface. |

## Project Structure

<pre lang="text"><code>
ArchitecturePatterns/                
├── ArchitecturePatterns.sln          
│
├── ArchitecturePatterns.DDD/        
│   ├── Models/
│   │   ├── Book.cs
│   │   └── ISBN.cs
│   ├── Services/
│   │   └── LibraryService.cs
│   ├── Program.cs
│   └── ArchitecturePatterns.DDD.csproj
│
├── ArchitecturePatterns.EDD/         
│   ├── Models/
│   │   └── Order.cs
│   ├── Events/
│   │   ├── OrderPlacedEvent.cs
│   │   └── EventPublisher.cs
│   ├── Services/
│   │   └── OrderService.cs
│   ├── Program.cs
│   └── ArchitecturePatterns.EDD.csproj
│
├── ArchitecturePatterns.TDD/         
│   ├── Models/
│   │   └── Calculator.cs
│   ├── Program.cs
│   ├── Tests/
│   │   └── CalculatorTests.cs                        
│   └── ArchitecturePatterns.TDD.csproj
</code></pre>

## Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (Preview)
- (Optional) [Visual Studio 2022+](https://visualstudio.microsoft.com/)
- (Optional) [Postman](https://www.postman.com/) for API testing

> **Note:** Swagger UI (via Swashbuckle) may not yet work in .NET 9 preview. Downgrade to `.NET 8` temporarily if needed.

## Setup

```bash
# Clone the repo
git clone https://github.com/yourusername/ArchitecturePatterns.git
cd ArchitecturePatterns

# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Run each project
dotnet run --project ArchitecturePatterns.DDD
dotnet run --project ArchitecturePatterns.EDD
dotnet run --project ArchitecturePatterns.TDD
