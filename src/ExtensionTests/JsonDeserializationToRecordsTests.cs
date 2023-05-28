namespace ExtensionTests;
using Calebs.Extensions;

public class JsonDeserializationToRecordsTests
{
    [Fact]
    public void ShouldDeserializeToClass()
    {
        ExampleRecord m = ExampleStrings.JSON.FromJson<ExampleRecord>();

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
        ExampleRecord m = Json.FromJson<ExampleRecord>();

        m.FirstName.Should().Be("Caleb");
        m.LastName.Should().Be("Jenkins");
        m.Priority.Should().Be(ExampleEnum.Low);
    }

    [Fact]
    public void MissingEnumShouldDefault()
    {
        ExampleRecord m = ExampleStrings.JsonMissingEnum.FromJson<ExampleRecord>();

        m.FirstName.Should().Be("Caleb");
        m.LastName.Should().Be("Jenkins");


        //m.Priority.Should().Be(ExampleEnum.High);

        // In a Class, deserializing from Jason - missing enum, the default set value get's asigned
        // In a Record, deserializing from Json - missing enum, the first value in the enum is used. 
    }

    [Fact]
    public void ShouldHandelMissingProperties()
    {
        ExampleRecord m = ExampleStrings.JsonMissingProperty.FromJson<ExampleRecord>();

        m.FirstName.Should().BeNullOrEmpty();
        m.LastName.Should().Be("Jenkins");
        m.Priority.Should().Be(ExampleEnum.Low);
    }
}

