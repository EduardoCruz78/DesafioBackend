# Desafio Backend

Implementacao do dominio do desafio de indicadores seguindo a estrutura do projeto: projetos separados para dominio, testes unitarios e utilitarios de
teste com Object Mothers.

## Projetos

- `src/Desafio.Indicators.Domain`: entidades, enum e regras de dominio.
- `tests/Desafio.Indicators.Domain.UnitTests`: testes unitarios do dominio.
- `tests/Desafio.Indicators.Tests.Utils`: Object Mothers usados nos testes.

## Validacao

```powershell
dotnet test Desafio.Indicators.sln
```
