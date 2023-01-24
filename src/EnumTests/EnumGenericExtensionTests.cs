using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayingWithEnumsLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnumTests;

[TestClass]
public class EnumGenericExtensionTests
{
    [TestMethod]
    public void ToList_Should_Return_A_List_of_Values()
    {
        var list = typeof(OptionsWithDescriptions).ToList();
        Assert.IsNotNull(list);
        var stringValue = list.ToDelimitedList(",");
    }

    [TestMethod]
    public void Non_Enum_Should_Throw_an_Exception()
    {
        Assert.ThrowsException<ArgumentException>(() => typeof(int).ToList());
        Assert.ThrowsException<ArgumentException>(() => typeof(string).ToList());
        Assert.ThrowsException<ArgumentException>(() => typeof(object).ToList());
    }

    [TestMethod]
    public void should_validate_property()
    {
        var sut = new ExampleClassGeneric() { Size = "blah" };
        Assert.IsFalse(ModelValidation.IsValid(sut));
    }

    [TestMethod]
    public void should_validate_found_property_to_true()
    {
        var sut = new ExampleClassGeneric() { Size = "Small" };
        Assert.IsTrue(ModelValidation.IsValid(sut));
    }

    [TestMethod]
    public void should_validate_property_even_if_case_is_off()
    {
        var sut = new ExampleClassGeneric() { Size = "sMall" };
        Assert.IsTrue(ModelValidation.IsValid(sut));
    }

    [TestMethod]
    public void should_validate_property_even_if_missing_but_not_required()
    {
        var sut = new ExampleClassGeneric() { Size = "" };
        Assert.IsTrue(ModelValidation.IsValid(sut));
    }

    [TestMethod]
    public void should_validate_when_required()
    {
        var sut = new RequiredPropertyClassGeneric() { Size = "" };
        Assert.IsFalse(ModelValidation.IsValid(sut));
    }

    [TestMethod]
    public void should_validate_when_required_and_populated()
    {
        var sut = new RequiredPropertyClassGeneric() { Size = "sMall" };
        Assert.IsTrue(ModelValidation.IsValid(sut));
    }

    [TestMethod]
    public void should_validate_when_required_and_populated_incorrectly()
    {
        var sut = new RequiredPropertyClassGeneric() { Size = "blah" };
        Assert.IsFalse(ModelValidation.IsValid(sut));
    }

    [TestMethod]
    public void should_validate_with_case_sensitivity_when_selected()
    {
        var sut = new CaseSensitivePropertyClassGeneric() { Size = "sMall" };
        Assert.IsFalse(ModelValidation.IsValid(sut));
    }
    [TestMethod]
    public void should_validate_with_case_sensitivity_when_selected_and_matches()
    {
        var sut = new CaseSensitivePropertyClassGeneric() { Size = "Small" };
        Assert.IsTrue(ModelValidation.IsValid(sut));
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
    public string Size { get; set; }
}

public class RequiredPropertyClassGeneric
{
    [Required(), EnumStringValidator<OptionsWithDescriptions>]
    public string Size { get; set; }
}

public class CaseSensitivePropertyClassGeneric
{
    [Required(), EnumStringValidator<OptionsWithDescriptions>(false)]
    public string Size { get; set; }
}
