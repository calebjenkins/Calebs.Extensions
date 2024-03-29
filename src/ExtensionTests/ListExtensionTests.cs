﻿
namespace ExtensionTests;

using Calebs.Extensions;

public class ListExtensionTests
{
    [Fact]
    public void ShouldCombineLists()
    {
        IList<string> l1 = new List<string>()
        {
            "One",
            "two",
            "three"
        };

        IList<string> l2 = new List<string>()
        {
            "four",
            "five"
        };

        l1.Count.Should().Be(3);
        l2.Count.Should().Be(2);

        l1.AddRange<string>(l2);

        l1.Count.Should().Be(5);

        l2.Count.Should().Be(2);
    }

    [Fact]
    public void AddUnlessBlank_shouldNotAddBlankItems()
    {
        var myList = new List<string>();

        myList.AddUnlessBlank("one");
        myList.AddUnlessBlank("two");
        myList.AddUnlessBlank("three");

        myList.Count.Should().Be(3);

        myList.AddUnlessBlank(string.Empty);
        myList.Count.Should().Be(3);

        myList.AddUnlessBlank("");
        myList.Count.Should().Be(3);

        myList.AddUnlessBlank(null);
        myList.Count.Should().Be(3);
    }
}

