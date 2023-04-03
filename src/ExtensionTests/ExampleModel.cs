namespace ExtensionTests;

public class ExampleModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ExampleEnum Priority { get; set; } = ExampleEnum.Default;
}

public record ExampleRecord(
    string FirstName,
    string LastName,
    ExampleEnum Priority = ExampleEnum.Default);

// In a Class, deserializing from Jason - missing enum, the default value get's asigned
// In a Record, deserializing from Json - missing enum, the first value in the enum is used. 
public enum ExampleEnum { High, Med, Low, Default }
