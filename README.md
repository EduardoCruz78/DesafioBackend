# Desafio Backend Qualyteam

Implementacao do dominio do desafio de indicadores seguindo a estrutura do projeto
`Qualyteam.Risks`: projetos separados para dominio, testes unitarios e utilitarios de
teste com Object Mothers.

## Projetos

- `src/Qualyteam.Indicators.Domain`: entidades, enum e regras de dominio.
- `tests/Qualyteam.Indicators.Domain.UnitTests`: testes unitarios do dominio.
- `tests/Qualyteam.Indicators.Tests.Utils`: Object Mothers usados nos testes.

## Validacao

```powershell
dotnet test Qualyteam.Indicators.sln
```
