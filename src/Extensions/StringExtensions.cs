using System;
using System.Text;

namespace Calebs.Extensions;

public static class StringExtensions
{
    public static bool IsNotNullOrEmpty(this string value)
    {
        return !String.IsNullOrEmpty(value);
    }

    public static bool IsNullOrEmpty(this string value)
    {
        return String.IsNullOrEmpty(value);
    }

    public static bool Compare(this string string1, string string2)
    {
        var returnValue = false;
        if (string1.IsNotNullOrEmpty())
        {
            returnValue = string1.Equals(string2, StringComparison.CurrentCultureIgnoreCase);
        }
        return returnValue;
    }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    public static string ValueOrEmpty(this string? value)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    {
        if (value.IsNullOrEmpty())
        {
            return string.Empty;

        }
        return value;
    }

    public static string Times(this string text, int times)
    {
        if (times < 0) { throw new ArgumentOutOfRangeException(nameof(times), "Times cannot be a negative number"); }

        var sb = new StringBuilder(times);
        for (var i = 0; i < times; i++)
        {
            sb.Append(text);
        }
        return sb.ToString();
    }
}

public static class IntExtensions
{
    public static string RandomText(this int length)
    {
        // Note: we use a GUID to be lazy - there are MUCH more performant ways to do this! 

        if (length <0) throw new ArgumentOutOfRangeException($"{nameof(length)} must be a positive number");

        if (length > 1000) throw new ArgumentOutOfRangeException($"{nameof(length)} must be below 1000 - this is too high!");

        // shortcut - just do it!
        if (length < 33)
            return Guid.NewGuid().ToString("N").Substring(0, length);


        // Figure out randomness for larger numbers. 
        // TODO: this is a cringy way to do this. Move to better perf <span> at some point!
        int times = 1;
        if(length > 32)
        {
            times = (length / 32) + 1;
        }

        var returnValue = new StringBuilder(times * 32);
        for(int i = 0; i < times; i++)
        {
            returnValue.Append(Guid.NewGuid().ToString("N"));
        }
        
        var tmpTxt = returnValue.ToString();
        return tmpTxt.Substring(0, length);
    }
}

