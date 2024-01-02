
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

public class ObjectExtensionTests
{
    [Fact]
    public void Nullable_Objects_Should_Return_Empty_String()
    {
        ExampleModel m = null;
        var result = m.ToSafeString();
        result.IsNullOrEmpty().Should().BeTrue();
    }

    [Fact]
    public void Int_Should_Return_String_Value()
    {
        int five = 5;
        var result = five.ToSafeString();
        result.Should().Be("5");
    }
}

