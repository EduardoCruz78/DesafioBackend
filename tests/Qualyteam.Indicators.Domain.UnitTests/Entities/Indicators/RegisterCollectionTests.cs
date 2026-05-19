namespace Qualyteam.Indicators.Domain.UnitTests.Entities.Indicators;

public sealed class RegisterCollectionTests
{
    [Fact]
    public void RegisterCollection_ShouldThrowException_WhenThereIsAlreadyACollectionForDate()
    {
        var indicator = IndicatorMother.AverageCalls();
        var date = new DateOnly(2023, 2, 1);
        indicator.RegisterCollection(date: date, value: 12);

        var collection = () => indicator.RegisterCollection(date: date, value: 7);

        collection
            .Should().Throw<InvalidOperationException>()
            .WithMessage("There is already a collection registered for this date.");
    }

    [Fact]
    public void RegisterCollection_ShouldAddCollectionWithSuccess()
    {
        var indicator = IndicatorMother.AverageCalls();
        var date = new DateOnly(2023, 2, 1);
        const decimal value = 12;

        var collection = indicator.RegisterCollection(
            date: date,
            value: value
        );

        using (new AssertionScope())
        {
            collection.Id.Should().NotBeEmpty();
            collection.Date.Should().Be(date);
            collection.Value.Should().Be(value);

            indicator.Collections.Should().ContainSingle();
            indicator.Collections.Should().Contain(collection);
        }
    }
}
