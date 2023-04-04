
namespace ExtensionTests;

using Calebs.Extensions;

public class JsonSerializationTests
{
    [Fact]
    public void ShouldSerializeClasses()
    {
        var m = new ExampleModel() { FirstName = "Caleb", LastName = "Jenkins", Priority = ExampleEnum.Low };
        var json = m.ToJson();

        json.Should().Contain("Jenkins");
        json.Should().ContainAny($"\"FirstName\":\"Caleb\"");
        json.Should().ContainAny("\"Priority\":\"Low\"");

    }

    [Fact]
    public void ShouldSerializeRecords()
    {
        var m = new ExampleRecord("Caleb", "Jenkins", ExampleEnum.Med);
        var json = m.ToJson();

        json.Should().Contain("Jenkins");
        json.Should().ContainAny($"\"FirstName\":\"Caleb\"");
        json.Should().ContainAny("\"Priority\":\"Med\"");
    }
}

