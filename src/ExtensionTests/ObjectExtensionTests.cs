
namespace ExtensionTests;

using Calebs.Extensions;

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

