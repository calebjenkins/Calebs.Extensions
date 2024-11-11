
namespace ExtensionTests;

using Calebs.Extensions;

public class IntExtensionTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(32)]
    public void RandomTextUnder32(int value)
    {
        value.RandomText().Length.Should().Be(value);
    }

    [Theory]
    [InlineData(33)]
    [InlineData(100)]
    [InlineData(1000)]
    public void RandomTextOver32_Below1000_LongRunning(int value)
    {
        value.RandomText().Length.Should().Be(value);
    }

    [Theory]
    [InlineData (0)]
    [InlineData(-1)]
    [InlineData(-10)]
    [InlineData (1001)]
    [InlineData(5000)]
    public void RandomTextBelowZero_or_Over1000_Should_Thrown_Exception(int value)
    {
        try
        {
            var _ = value.RandomText();
        }
        catch (Exception ex)
        {
            ex.Should().BeOfType<ArgumentOutOfRangeException>();
        }
    }


}