using System.Reflection.Metadata;
using Calebs.Extensions;

namespace ExtensionTests;
public class JsonDeserializationToClassesTests
{

    [Fact]
    public void ShouldDeserializeToClass()
    {
        ExampleModel m = ExampleStrings.JSON.FromJson<ExampleModel>();

        m.FirstName.Should().Be("Caleb");
        m.LastName.Should().Be("Jenkins");
        m.Priority.Should().Be(ExampleEnum.Low);
    }

    [Theory]
    [InlineData(ExampleStrings.JSON)]
    //[InlineData(JsonEnumAsString)] // Fails.. needs to either be an index number or the word
    [InlineData(ExampleStrings.JsonEnumAsWord)]
    [InlineData(ExampleStrings.JsonExtraProperties)]
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
        ExampleModel m = ExampleStrings.JsonMissingEnum.FromJson<ExampleModel>();

        m.FirstName.Should().Be("Caleb");
        m.LastName.Should().Be("Jenkins");
        m.Priority.Should().Be(ExampleEnum.Default);
    }

    [Fact]
    public void ShouldHandelMissingProperties()
    {
        ExampleModel m = ExampleStrings.JsonMissingProperty.FromJson<ExampleModel>();

        m.FirstName.Should().BeNullOrEmpty();
        m.LastName.Should().Be("Jenkins");
        m.Priority.Should().Be(ExampleEnum.Low);
    }
}

