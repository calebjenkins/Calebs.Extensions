
namespace JasonExtensionTests;

public class JsonSerializationTests
{
    [Fact]
    public void ShouldSerializeClasses()
    {
        var m = new ExampleModel() { FirstName = "Caleb", LastName = "Jenkins", Priority = ExampleEnum.Low };
        var json = m.ToJson();

        json.Should().Contain("Jenkins");
        json.Should().ContainAny($"\"FirstName\":\"Caleb\"");

    }
}

