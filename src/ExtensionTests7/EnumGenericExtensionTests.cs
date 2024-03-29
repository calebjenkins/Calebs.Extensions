using Calebs.Extensions;
using Calebs.Extensions.Validators;

namespace ExtensionTests7;

public class EnumGenericExtensionTests
{
    [Fact]
    public void ToList_Should_Return_A_List_of_Values()
    {
        var list = typeof(OptionsWithDescriptions).ToList();
        list.Should().NotBeNull();
        var stringValue = list.ToDelimitedList(",");
        list.Should().NotBeEmpty();
    }

    [Fact]
    public void Non_Enum_Should_Throw_an_Exception()
    {

        Action act = () => typeof(int).ToList();
        act.Should().Throw<ArgumentException>();

        act = () => typeof(int).ToList();
        act.Should().Throw<ArgumentException>();

        act = () => typeof(string).ToList();
        act.Should().Throw<ArgumentException>();

        act = () => typeof(object).ToList();
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void should_validate_property()
    {
        var sut = new ExampleClassGeneric() { Size = "blah" };
        ModelValidation.IsValid(sut).Should().Be(false);
    }

    [Fact]
    public void should_validate_found_property_to_true()
    {
        var sut = new ExampleClassGeneric() { Size = "Small" };
        ModelValidation.IsValid(sut).Should().Be(true);
    }

    [Fact]
    public void should_validate_property_even_if_case_is_off()
    {
        var sut = new ExampleClassGeneric() { Size = "sMall" };
        ModelValidation.IsValid(sut).Should().Be(true);
    }

    [Fact]
    public void should_validate_property_even_if_missing_but_not_required()
    {
        var sut = new ExampleClassGeneric() { Size = "" };
        ModelValidation.IsValid(sut).Should().Be(true);
    }

    [Fact]
    public void should_validate_when_required()
    {
        var sut = new RequiredPropertyClassGeneric() { Size = "" };
        ModelValidation.IsValid(sut).Should().Be(false);
    }

    [Fact]
    public void should_validate_when_required_and_populated()
    {
        var sut = new RequiredPropertyClassGeneric() { Size = "sMall" };
        ModelValidation.IsValid(sut).Should().Be(true);
    }

    [Fact]
    public void should_validate_when_required_and_populated_incorrectly()
    {
        var sut = new RequiredPropertyClassGeneric() { Size = "blah" };
        ModelValidation.IsValid(sut).Should().Be(false);
    }

    [Fact]
    public void should_validate_with_case_sensitivity_when_selected()
    {
        var sut = new CaseSensitivePropertyClassGeneric() { Size = "sMall" };
        ModelValidation.IsValid(sut).Should().Be(false);
    }
    [Fact]
    public void should_validate_with_case_sensitivity_when_selected_and_matches()
    {
        var sut = new CaseSensitivePropertyClassGeneric() { Size = "Small" };
        ModelValidation.IsValid(sut).Should().Be(true);
    }
}

public class ModelValidationGeneric
{
    public static bool IsValid(object model)
    {
        var context = new ValidationContext(model, null, null);
        var results = new List<ValidationResult>();

        return Validator.TryValidateObject(model, context, results, true);
    }
}
public class ExampleClassGeneric
{

    [EnumStringValidator<OptionsWithDescriptions>()]
    public string Size { get; set; } = string.Empty;
}

public class RequiredPropertyClassGeneric
{
    [Required(), EnumStringValidator<OptionsWithDescriptions>]
    public string Size { get; set; } = string.Empty;
}

public class CaseSensitivePropertyClassGeneric
{
    [Required(), EnumStringValidator<OptionsWithDescriptions>(false)]
    public string Size { get; set; } = string.Empty;
}
