namespace Qualyteam.Indicators.Domain.Entities;

public sealed class IndicatorCollection : Entity
{
    public const decimal ValueMinValue = 0;

    public DateOnly Date { get; private set; }
    public decimal Value { get; private set; }

    private IndicatorCollection()
    {
    }

    public IndicatorCollection(
        DateOnly date,
        decimal value
    )
    {
        Guard.IsGreaterThanOrEqualTo(value, ValueMinValue, nameof(value));

        Id = Guid.NewGuid();
        Date = date;
        Value = value;
    }
}
