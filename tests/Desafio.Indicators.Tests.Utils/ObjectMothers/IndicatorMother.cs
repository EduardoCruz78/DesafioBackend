using System.Collections.Generic;

namespace Desafio.Indicators.Tests.Utils.ObjectMothers;

public static class IndicatorMother
{
    public const string DefaultName = "Default";
    public const string AverageCallsName = "Media de ligacoes";
    public const string TotalSalesName = "Total de Vendas";

    public static Indicator Default()
        => Create(name: DefaultName);

    public static Indicator AverageCalls()
        => Create(
            name: AverageCallsName,
            calculationType: IndicatorCalculationType.Average
        );

    public static Indicator TotalSales()
        => Create(
            name: TotalSalesName,
            calculationType: IndicatorCalculationType.Sum
        );

    public static Indicator Create(
        string name = DefaultName,
        IndicatorCalculationType calculationType = IndicatorCalculationType.Sum
    )
        => new(
            name: name,
            calculationType: calculationType
        );

    public static IEnumerable<Indicator> GetAll()
    {
        yield return Default();
        yield return AverageCalls();
        yield return TotalSales();
    }
}
