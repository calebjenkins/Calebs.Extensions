using System;

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
}

