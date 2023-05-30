
namespace ExtensionTests;

using Calebs.Extensions;

public class StringExtensionTests
{
    [Fact]
    public void ShouldReturnEmptyStringOnNull()
    {
        string? value = null;
        string v2 = value.ValueOrEmpty();

        v2.Should().Be(String.Empty);
    }

    [Fact]
    public void ShouldReturnValueIfNotNull()
    {
        string? value = "hello";
        string v2 = value.ValueOrEmpty();

        v2.Should().Be(value);
    }
}

