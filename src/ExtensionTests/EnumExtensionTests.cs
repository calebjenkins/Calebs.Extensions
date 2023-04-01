using Calebs.Extensions.Validators;

namespace EnumTests;

public class EnumExtensionTests
{
	[Fact]
	public void ToList_Should_Return_A_List_of_Values()
	{
		var list = typeof(OptionsWithDescriptions).ToList();
		list.Should().NotBeNull();
		var stringValue = list.ToDelimitedList(",");
	}

    [Fact]
    public void Non_Enum_Should_Throw_an_Exception()
	{
		Action act = () => typeof(int).ToList();
		act.Should().Throw<ArgumentException>();

        Action act2 = () => typeof(string).ToList();
        act2.Should().Throw<ArgumentException>();

        Action act3 = () => typeof(object).ToList();
        act3.Should().Throw<ArgumentException>();
    }

	[Fact]
	public void should_validate_property()
	{
		var sut = new ExampleClass() { Size = "blah" };
		ModelValidation.IsValid(sut).Should().BeFalse();
	}

    [Fact]
    public void should_validate_found_property_to_true()
	{
		var sut = new ExampleClass() { Size = "Small" };
		ModelValidation.IsValid(sut).Should().BeTrue();
	}

    [Fact]
    public void should_validate_property_even_if_case_is_off()
	{
		var sut = new ExampleClass() { Size = "sMall" };
		ModelValidation.IsValid(sut).Should().BeTrue();
	}

    [Fact]
    public void should_validate_property_even_if_missing_but_not_required()
	{
		var sut = new ExampleClass() { Size = "" };
        ModelValidation.IsValid(sut).Should().BeTrue();
	}

    [Fact]
    public void should_validate_when_required()
	{
		var sut = new RequiredPropertyClass() { Size = "" };
        ModelValidation.IsValid(sut).Should().BeFalse();
	}

    [Fact]
    public void should_validate_when_required_and_populated()
	{
		var sut = new RequiredPropertyClass() { Size = "sMall" };
        ModelValidation.IsValid(sut).Should().BeTrue();
	}

    [Fact]
    public void should_validate_when_required_and_populated_incorrectly()
	{
		var sut = new RequiredPropertyClass() { Size = "blah" };
        ModelValidation.IsValid(sut).Should().BeFalse();
	}

    [Fact]
    public void should_validate_with_case_sensitivity_when_selected()
	{
		var sut = new CaseSensitivePropertyClass() { Size = "sMall" };
        ModelValidation.IsValid(sut).Should().BeFalse();
	}
    
	[Fact]
    public void should_validate_with_case_sensitivity_when_selected_and_matches()
	{
		var sut = new CaseSensitivePropertyClass() { Size = "Small" };
        ModelValidation.IsValid(sut).Should().BeTrue();
	}

}
public class ModelValidation
{
	public static bool IsValid(object model)
	{
		var context = new ValidationContext(model, null, null);
		var results = new List<ValidationResult>();

		return Validator.TryValidateObject(model, context, results, true);
	}
}

public class ExampleClass
{

	[EnumStringValidatorAttribute(typeof(OptionsWithDescriptions))]
	public string Size { get; set; }
}

public class RequiredPropertyClass
{
	[Required(), EnumStringValidatorAttribute(typeof(OptionsWithDescriptions))]
	public string Size { get; set; }
}

public class CaseSensitivePropertyClass
{
	[Required(), EnumStringValidatorAttribute(typeof(OptionsWithDescriptions), false)]
	public string Size { get; set; }
}


