using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ExtensionTests7;

public class ModelValidation
{
    public static bool IsValid(object model)
    {
        var context = new ValidationContext(model, null, null);
        var results = new List<ValidationResult>();

        return Validator.TryValidateObject(model, context, results, true);
    }
}

public enum Options
{
	Unknown,
	Medium,
	Small,
	Large
}

public enum Options2
{
	Large,
	Small,
	Medium,
	Unknown
}

[DataContract]
public enum OptionWithEnumMember
{
	[EnumMember(Value = "Large")]
	Largish,
	[EnumMember(Value = "Medium")]
	Avg,
	[EnumMember(Value = "Small")]
	ReallyLittle,
    [EnumMember(Value = "NoIdea")]
    Unknown
}

public enum OptionsWithDescriptions
{
	[Description("Smallish")]
	Small,

	[Description("Largish")]
	[ValueForSystemX("SuperSized")]
	[ValueForSystemY("MuyBig")]
	Large,

	[Description("No Idea")]
	Unknown,

	[Description("Avg I guess")]
	Medium
}

public class MessageWithOptionsEnum
{
	public Options Options { get; set; } = Options.Unknown;
}

public class MessageWithOptions2Enum
{
	public Options2 Options { get; set; } = Options2.Unknown;
}
public class MessageWithOptions1EnumWithAttribute
{
	[JsonConverter(typeof(StringEnumConverter))]
	public Options Options { get; set; } = Options.Unknown;
}

public class MessageWithStringOptions
{
	public string Options { get; set; } = string.Empty;
}

public class MessageWithEnumBacking
{

	[JsonIgnore] //[NonSerialized]
	public Options Options
	{
		get
		{
			var retOption = Options.Unknown;
			return (Enum.TryParse<Options>(_options, out retOption)) ? retOption : Options.Unknown;
		}
		set { _options = value.ToString(); }
	}

	[JsonProperty("Options")]
	public string _options { get; set; } = string.Empty;
}

public class MessageWithEnumMemberOptions
{
	public OptionWithEnumMember Options { get; set; } = OptionWithEnumMember.Unknown; 
}

public class MessageOptionsWithDescriptions
{
	public OptionsWithDescriptions Options { get; set; } = OptionsWithDescriptions.Unknown;
}

public class MessageOptionsCustomAttributes
{
	public MessageOptionsCustomAttributes Options { get; set; } = new MessageOptionsCustomAttributes();
}

public class ValueForSystemX : DescriptionAttribute
{
	public ValueForSystemX(string description) : base(description)
	{
	}
}

public class ValueForSystemY : DescriptionAttribute
{
	public ValueForSystemY(string description) : base(description)
	{
	}
}
