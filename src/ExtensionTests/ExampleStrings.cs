namespace ExtensionTests;

public class ExampleStrings
{
    public const string JSON = "{\"FirstName\":\"Caleb\",\"LastName\":\"Jenkins\",\"Priority\":2}";
    public const string JsonEnumAsString = "{\"FirstName\":\"Caleb\",\"LastName\":\"Jenkins\",\"Priority\":\"2}\"";
    public const string JsonEnumAsWord = "{\"FirstName\":\"Caleb\",\"LastName\":\"Jenkins\",\"Priority\":\"Low\"}";
    public const string JsonMissingEnum = "{\"FirstName\":\"Caleb\",\"LastName\":\"Jenkins\"}";
    public const string JsonMissingProperty = "{\"LastName\":\"Jenkins\",\"Priority\":2}";
    public const string JsonExtraProperties = @"{""FirstName"":""Caleb"",""LastName"":""Jenkins"",""Priority"":2,""State"":""TX"",""Country"":""USA""}";
}



