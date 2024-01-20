using System;
using System.Collections.Generic;

namespace Calebs.Extensions;

public static class ListExtensions
{
    public static string ToDelimitedList(this List<string> list, string delimiter)
    {
        return string.Join(delimiter, list.ToArray());
    }

    public static void ToUpper(this IList<string> list)
    {
        for (var i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToUpper();
        }
    }

    public static void AddUnlessBlank(this IList<string> list, string value)
    {
        if(value.IsNullOrEmpty())
        {
            return;
        }

        list.Add(value);
    }

    public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
        if (items == null) throw new ArgumentNullException(nameof(items));

        if (list is List<T> asList)
        {
            asList.AddRange(items);
        }
        else
        {
            foreach (var item in items)
            {
                list.Add(item);
            }
        }
    }
}