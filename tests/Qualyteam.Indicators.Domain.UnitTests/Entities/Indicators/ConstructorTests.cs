namespace Qualyteam.Indicators.Domain.UnitTests.Entities.Indicators;

public sealed class ConstructorTests
{
    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void Constructor_ShouldThrowException_WhenNameIsWhiteSpace(string name)
    {
        var indicator = () => IndicatorMother.Create(name: name);

        indicator
            .Should().Throw<ArgumentException>()
            .WithParameterName("name");
    }

    [Fact]
    public void Constructor_ShouldThrowException_WhenNameIsGreaterThan150Characters()
    {
        var indicator = () => IndicatorMother.Create(name: new string('a', 151));

        indicator
            .Should().Throw<ArgumentOutOfRangeException>()
            .WithParameterName("name");
    }

    [Fact]
    public void Constructor_ShouldThrowException_WhenCalculationTypeIsInvalid()
    {
        var indicator = () => IndicatorMother.Create(
            calculationType: (IndicatorCalculationType)99
        );

        indicator
            .Should().Throw<ArgumentOutOfRangeException>()
            .WithParameterName("calculationType");
    }

    [Fact]
    public void Constructor_ShouldCreateWithSuccess()
    {
        const string name = "Media de ligacoes";
        const IndicatorCalculationType calculationType = IndicatorCalculationType.Average;

        var indicator = IndicatorMother.Create(
            name: name,
            calculationType: calculationType
        );

        using (new AssertionScope())
        {
            indicator.Id.Should().NotBeEmpty();
            indicator.Name.Should().Be(name);
            indicator.CalculationType.Should().Be(calculationType);
            indicator.Collections.Should().BeEmpty();
        }
    }
}
