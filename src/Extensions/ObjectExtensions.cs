namespace Calebs.Extensions;

public static class ObjectExtensions
{
    public static string ToSafeString(this object o)
    {
        return o?.ToString() ?? string.Empty;
    }
}

