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

    //[DataTestMethod]
    //[DataRow(JSON)]
    //[DataRow(JsonEnumAsString)]
    //[DataRow(JsonEnumAsWord)]
    ////[DataRow(JsonMissingEnum)]
    //[DataRow(JsonExtraProperties)]
    public void ShouldDeserializeMultipleJsonFormatsToClass(string Json)
    {
        ExampleModel m = Json.FromJson<ExampleModel>();

        m.FirstName.Should().Be("Caleb");
        m.LastName.Should().Be("Jenkins");
        m.Priority.Should().Be(ExampleEnum.Low);
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
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ExampleEnum Priority { get; set; }
}

public record ExampleRecord(string FirstName, string LastName, ExampleEnum Priority);
public enum ExampleEnum { High, Med, Low }

