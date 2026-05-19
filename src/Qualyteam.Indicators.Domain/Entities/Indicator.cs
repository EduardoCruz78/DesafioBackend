namespace Qualyteam.Indicators.Domain.Entities;

public sealed class Indicator : AggregateRoot
{
    public const int NameMaxLength = 150;
    public const int ResultDecimalPlaces = 2;

    private readonly List<IndicatorCollection> _collections = [];

    public string Name { get; private set; } = null!;
    public IndicatorCalculationType CalculationType { get; private set; }
    public IReadOnlyCollection<IndicatorCollection> Collections => _collections;

    private Indicator()
    {
    }

    public Indicator(
        string name,
        IndicatorCalculationType calculationType
    )
    {
        Guard.IsNotWhiteSpace(name, nameof(name));
        Guard.IsLessThanOrEqualTo(name.Length, NameMaxLength, nameof(name));
        EnsureCalculationTypeIsValid(calculationType);

        Id = Guid.NewGuid();
        Name = name;
        CalculationType = calculationType;
    }

    public IndicatorCollection RegisterCollection(
        DateOnly date,
        decimal value
    )
    {
        if (_collections.Any(collection => collection.Date == date))
            throw new InvalidOperationException("There is already a collection registered for this date.");

        var collection = new IndicatorCollection(
            date: date,
            value: value
        );

        _collections.Add(collection);

        return collection;
    }

    public decimal CalculateResult()
    {
        if (_collections.Count == 0)
            return 0;

        var result = CalculationType switch
        {
            IndicatorCalculationType.Sum => _collections.Sum(collection => collection.Value),
            IndicatorCalculationType.Average => _collections.Average(collection => collection.Value),
            _ => throw new InvalidOperationException("Invalid indicator calculation type.")
        };

        return decimal.Round(
            result,
            ResultDecimalPlaces,
            MidpointRounding.AwayFromZero
        );
    }

    private static void EnsureCalculationTypeIsValid(IndicatorCalculationType calculationType)
    {
        if (!Enum.IsDefined(calculationType))
            throw new ArgumentOutOfRangeException(nameof(calculationType));
    }
}
