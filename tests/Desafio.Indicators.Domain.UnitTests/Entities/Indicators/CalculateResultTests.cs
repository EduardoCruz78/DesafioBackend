namespace Desafio.Indicators.Domain.UnitTests.Entities.Indicators;

public sealed class CalculateResultTests
{
    [Fact]
    public void CalculateResult_ShouldReturnZero_WhenThereAreNoCollections()
    {
        var indicator = IndicatorMother.AverageCalls();

        var result = indicator.CalculateResult();

        result.Should().Be(0);
    }

    [Fact]
    public void CalculateResult_ShouldReturnAverage_WhenCalculationTypeIsAverage()
    {
        var indicator = IndicatorMother.AverageCalls();
        indicator.RegisterCollection(date: new DateOnly(2023, 2, 1), value: 12);
        indicator.RegisterCollection(date: new DateOnly(2023, 2, 2), value: 7);
        indicator.RegisterCollection(date: new DateOnly(2023, 2, 3), value: 16);
        indicator.RegisterCollection(date: new DateOnly(2023, 2, 4), value: 11);
        indicator.RegisterCollection(date: new DateOnly(2023, 2, 5), value: 9);
        indicator.RegisterCollection(date: new DateOnly(2023, 2, 6), value: 10);

        var result = indicator.CalculateResult();

        result.Should().Be(10.83m);
    }

    [Fact]
    public void CalculateResult_ShouldReturnSum_WhenCalculationTypeIsSum()
    {
        var indicator = IndicatorMother.TotalSales();
        indicator.RegisterCollection(date: new DateOnly(2023, 2, 1), value: 37000);
        indicator.RegisterCollection(date: new DateOnly(2023, 2, 2), value: 43500);
        indicator.RegisterCollection(date: new DateOnly(2023, 2, 3), value: 39780);
        indicator.RegisterCollection(date: new DateOnly(2023, 2, 4), value: 67800);
        indicator.RegisterCollection(date: new DateOnly(2023, 2, 5), value: 28000);
        indicator.RegisterCollection(date: new DateOnly(2023, 2, 6), value: 57900);

        var result = indicator.CalculateResult();

        result.Should().Be(273980);
    }
}
