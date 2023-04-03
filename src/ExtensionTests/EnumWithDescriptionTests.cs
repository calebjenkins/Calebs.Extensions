using Newtonsoft.Json;
using System;
using Calebs.Extensions;

namespace ExtensionTests;

public class EnumWithDescriptionTests
{
	[Fact]
	public void ShouldUseDescription()
	{
		var StartMsg = new MessageOptionsWithDescriptions() { Options = OptionsWithDescriptions.Large };
		var msgJson = JsonConvert.SerializeObject(StartMsg);

		var EndMsg = JsonConvert.DeserializeObject<MessageOptionsWithDescriptions>(msgJson);

		OptionsWithDescriptions.Large.ToString()
			.Should().Be(EndMsg.Options.ToString());
	}

	[Fact]
	public void ShouldUseDescriptionOrString()
	{
		var StartMsg = new MessageOptionsWithDescriptions() { Options = OptionsWithDescriptions.Large };
		var msgJson = JsonConvert.SerializeObject(StartMsg);

		var EndMsg = JsonConvert.DeserializeObject<MessageOptionsWithDescriptions>(msgJson);

		StartMsg.Options.ToString()
			.Should().Be(EndMsg.Options.ToString());
	}

	[Fact]
	public void ValidateToDescriptionExtension()
	{
		"Largish".Compare(OptionsWithDescriptions.Large.Description())
			.Should().BeTrue();
	}

    [Fact]
    public void ValidateToValueOrStringExtension()
	{
		"Largish".Compare(OptionsWithDescriptions.Large.Description<System.ComponentModel.DescriptionAttribute>())
			.Should().BeTrue();
	}

    [Fact]
    public void ValidateToValueOrStringExtension_With_Custom_Descriptor()
	{
		"SuperSized".Compare(OptionsWithDescriptions.Large.Description<ValueForSystemX>()).Should().BeTrue();
		"MuyBig".Compare(OptionsWithDescriptions.Large.Description<ValueForSystemY>()).Should().BeTrue();
        "Largish".Compare(OptionsWithDescriptions.Large.Description()).Should().BeTrue();
        "Large".Compare(OptionsWithDescriptions.Large.ToString()).Should().BeTrue();
    }

    [Fact]
    public void ValidateToValueOrStringExtension_With_CustomDescriptions_checking_vars()
	{
		var option = OptionsWithDescriptions.Large;
		"SuperSized".Compare(option.Description<ValueForSystemX>()).Should().BeTrue();
        "MuyBig".Compare(option.Description<ValueForSystemY>()).Should().BeTrue();
        "Largish".Compare(option.Description()).Should().BeTrue();
    }

    [Fact]
    public void ValidateToValueOrStringExtension_Uses_ToString_When_Descriptor_Is_Missing()
	{
		"Medium".Compare(OptionsWithDescriptions.Medium.Description<ValueForSystemX>()).Should().BeTrue();
    }
}
