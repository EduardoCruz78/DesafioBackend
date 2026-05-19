namespace Qualyteam.Indicators.Tests.Utils.ObjectMothers;

public static class IndicatorCollectionMother
{
    public static readonly DateOnly DefaultDate = new(2023, 2, 1);
    public const decimal DefaultValue = 10;

    public static IndicatorCollection Create(
        DateOnly? date = null,
        decimal value = DefaultValue
    )
        => new(
            date: date ?? DefaultDate,
            value: value
        );
}
