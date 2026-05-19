namespace Desafio.Indicators.Domain.UnitTests.Entities.IndicatorCollections;

public sealed class ConstructorTests
{
    [Fact]
    public void Constructor_ShouldThrowException_WhenValueIsNegative()
    {
        var collection = () => IndicatorCollectionMother.Create(value: -1);

        collection
            .Should().Throw<ArgumentOutOfRangeException>()
            .WithParameterName("value");
    }

    [Fact]
    public void Constructor_ShouldCreateWithSuccess()
    {
        var date = new DateOnly(2023, 2, 1);
        const decimal value = 12;

        var collection = IndicatorCollectionMother.Create(
            date: date,
            value: value
        );

        using (new AssertionScope())
        {
            collection.Id.Should().NotBeEmpty();
            collection.Date.Should().Be(date);
            collection.Value.Should().Be(value);
        }
    }
}
