
using Newt =  Newtonsoft.Json;
using Conv = Newtonsoft.Json.Converters;


namespace Calebs.Extensions;

public static class JsonExtensions
{
    public static T FromJson<T>(this string json)
    {
        T result = default(T);
        result = Newt.JsonConvert.DeserializeObject<T>(json);
        return result;
    }

    public static string ToJson(this object o)
    {
        var result = string.Empty;
        result = Newt.JsonConvert.SerializeObject(o, new Conv.StringEnumConverter());
        return result;
    }
}