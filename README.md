# Architecture Patterns (.NET 9)

A multi-project solution demonstrating three key architectural and development patterns in .NET:

- **DDD** — Domain-Driven Design  
- **EDD** — Event-Driven Design  
- **TDD** — Test-Driven Development  

Each pattern is implemented in a dedicated project with clear use cases and best practices.

## Projects in This Solution

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
