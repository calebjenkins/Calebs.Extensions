using System.Collections.Generic;

namespace Calebs.Extensions;

public static class ListExtensions
{ 
	public static string ToDelimitedList(this List<string> list, string delimiter)
	{
		return string.Join(delimiter, list.ToArray());
	}

	public static void ToUpper(this List<string> list)
	{
		for (var i = 0; i < list.Count; i++)
		{
			list[i] = list[i].ToUpper();
		}
	}
}
