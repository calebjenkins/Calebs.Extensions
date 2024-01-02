
namespace ExtensionTests;

using Calebs.Extensions;

public class StringExtensionTests
{
    [Fact]
    public void ShouldReturnEmptyStringOnNull()
    {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        string? value = null;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        string v2 = value.ValueOrEmpty();

        v2.Should().Be(String.Empty);
    }

    [Fact]
    public void ShouldReturnValueIfNotNull()
    {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        string? value = "hello";
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        string v2 = value.ValueOrEmpty();

        v2.Should().Be(value);
    }
}