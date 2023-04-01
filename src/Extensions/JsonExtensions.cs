
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Calebs.Extensions;

public static class JsonExtensions
{
    public static T FromJson<T>(this string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }

    public static string ToJson(this object o)
    {
        return JsonConvert.SerializeObject(o, new StringEnumConverter());
    }
}