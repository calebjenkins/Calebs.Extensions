using System;
using SCM = System.ComponentModel;
using Calebs.Extensions;

namespace EnumTests
{
	public class EnumParsingTests
	{
		[Fact]
		public void EnumParse_Should_Parse_ToString_Value()
		{
			var option = OptionsWithDescriptions.Large;
			var newOption = Enum.Parse<OptionsWithDescriptions>("Large");

			option.Should().Be(newOption);

			"SuperSized".Compare(option.Description<ValueForSystemX>()).Should().BeTrue();
            option.Description<ValueForSystemX>().Should().Be("SuperSized");


			"MuyBig".Compare(option.Description<ValueForSystemY>()).Should().BeTrue();
            "Largish".Compare(option.Description()).Should().BeTrue();
        }

        [Fact]
        public void EnumParse_Should_Fail_When_ToString_Value_Is_Wrong()
		{
			var option = OptionsWithDescriptions.Large;
			var match = Enum.TryParse<OptionsWithDescriptions>("blah", out var newOption);

			option.Should().NotBe(newOption);
		}

        [Fact]
        public void EnumParseSafe_Should_Parse_ToString_Value()
		{
			var option = OptionsWithDescriptions.Large;
			var newOption = "Large".Parse<OptionsWithDescriptions>();

			option.Should().Be(newOption);
			option.Should().Be(newOption.Value);
		}

        [Fact]
        public void EnumParseSafe_Should_Parse_To_Nullable()
		{
			var option = OptionsWithDescriptions.Large;
			var newOption = "blah".Parse<OptionsWithDescriptions>();

			newOption.Should().BeNull();
			newOption.HasValue.Should().BeFalse();
			newOption.Should().NotBe(option);
		}

        [Fact]
        public void EnumParse_Should_Parse_ToCustomValue_Value()
		{
			var option = OptionsWithDescriptions.Large;
			var newOption = "Large".Parse<OptionsWithDescriptions>();
			var optionFromDescription = "Largish".Parse<OptionsWithDescriptions, SCM.DescriptionAttribute>();
			var optionFromX = "SuperSized".Parse<OptionsWithDescriptions, ValueForSystemX>();

			option.Should().Be(newOption);
			option.Should().Be(optionFromDescription);
			option.Should().Be(optionFromX);
		}
	}
}
