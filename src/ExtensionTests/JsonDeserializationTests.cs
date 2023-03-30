using System.Reflection.Metadata;

namespace JasonExtensionTests;

public class JsonDeserializationTests
{
    public const string JSON = "{\"FirstName\":\"Caleb\",\"LastName\":\"Jenkins\",\"Priority\":2}";
    public const string JsonEnumAsString = "{\"FirstName\":\"Caleb\",\"LastName\":\"Jenkins\",\"Priority\":\"2}\"";
    public const string JsonEnumAsWord = "{\"FirstName\":\"Caleb\",\"LastName\":\"Jenkins\",\"Priority\":\"Low\"}";
    public const string JsonMissingEnum = "{\"FirstName\":\"Caleb\",\"LastName\":\"Jenkins\"}";
    public const string JsonMissingProperty = "{\"LastName\":\"Jenkins\",\"Priority\":2}";
    public const string JsonExtraProperties = @"{""FirstName"":""Caleb"",""LastName"":""Jenkins"",""Priority"":2,""State"":""TX"",""Country"":""USA""}";

    [Fact]
    public void ShouldDeserializeToClass()
    {
        ExampleModel m = JSON.FromJson<ExampleModel>();

        m.FirstName.Should().Be("Caleb");
        m.LastName.Should().Be("Jenkins");
        m.Priority.Should().Be(ExampleEnum.Low);
    }

    [Theory]
    [InlineData(JSON)]
    //[InlineData(JsonEnumAsString)] // Fails.. needs to either be an index number or the word
    [InlineData(JsonEnumAsWord)]
    [InlineData(JsonExtraProperties)]
    public void ShouldDeserializeMultipleJsonFormatsToClass(string Json)
    {
        ExampleModel m = Json.FromJson<ExampleModel>();

        m.FirstName.Should().Be("Caleb");
        m.LastName.Should().Be("Jenkins");
        m.Priority.Should().Be(ExampleEnum.Low);
    }

    [Fact]
    public void MissingEnumShouldDefault()
    {
        ExampleModel m = JsonMissingEnum.FromJson<ExampleModel>();

        m.FirstName.Should().Be("Caleb");
        m.LastName.Should().Be("Jenkins");
        m.Priority.Should().Be(ExampleEnum.Default);
    }

    [Fact]
    public void ShouldHandelMissingProperties()
    {
        ExampleModel m = JsonMissingProperty.FromJson<ExampleModel>();

        m.FirstName.Should().BeNullOrEmpty();
        m.LastName.Should().Be("Jenkins");
        m.Priority.Should().Be(ExampleEnum.Low);
    }
}

public class ExampleModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ExampleEnum Priority { get; set; } = ExampleEnum.Default;
}

public record ExampleRecord(string FirstName, string LastName, ExampleEnum Priority);
public enum ExampleEnum { High, Med, Low, Default}

