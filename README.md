# Indicators Domain (C# / .NET)

[![CI](https://github.com/EduardoCruz78/DesafioBackend/actions/workflows/ci.yml/badge.svg)](https://github.com/EduardoCruz78/DesafioBackend/actions/workflows/ci.yml)
![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4)
![Tests](https://img.shields.io/badge/tests-12%20passing-brightgreen)

Domain layer for a **performance indicators (KPI)** feature, written in C# with a DDD approach and built test-first.

An `Indicator` holds dated **collections** (measurements) and calculates its result as a **sum** or an **average**, depending on its calculation type.

## Domain rules

- An indicator needs a non-empty name (max. 150 characters) and a valid calculation type (`Sum` or `Average`).
- Only **one collection per date** is allowed for each indicator.
- Collection values cannot be negative.
- The result is rounded to **2 decimal places** (midpoint away from zero); an indicator with no collections returns `0`.
- Invariants are enforced inside the aggregate with guard clauses, so the entity can never be in an invalid state.

## Design

| Concept | Where |
|---|---|
| Aggregate root `Indicator` (owns its collections) | `src/Desafio.Indicators.Domain/Entities/Indicator.cs` |
| Entity `IndicatorCollection` | `src/Desafio.Indicators.Domain/Entities/IndicatorCollection.cs` |
| Base `Entity` / `AggregateRoot` | `src/Desafio.Indicators.Domain/Base/` |
| Unit tests per behavior (constructor, register, calculate) | `tests/Desafio.Indicators.Domain.UnitTests/` |
| Test data builders (Object Mother pattern) | `tests/Desafio.Indicators.Tests.Utils/ObjectMothers/` |

- Private setters and a read-only collection keep the aggregate encapsulated.
- Tests are organized one class per behavior, using **xUnit** and **FluentAssertions**.
- **Object Mothers** keep test setup short and readable.

## Running

Requires the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).

```bash
dotnet test Desafio.Indicators.sln
```

## Stack

C# · .NET 8 · xUnit · FluentAssertions · CommunityToolkit.Diagnostics (guard clauses) · GitHub Actions

---

<details>
<summary>🇧🇷 Em português</summary>

Camada de domínio de **indicadores de desempenho** em C#/.NET, com DDD e desenvolvimento orientado a testes. Um `Indicador` recebe coletas por data (uma por dia, sem valores negativos) e calcula o resultado por **soma** ou **média**, arredondado em 2 casas. São 12 testes unitários com xUnit, FluentAssertions e Object Mothers. Para rodar: `dotnet test Desafio.Indicators.sln`.

</details>
