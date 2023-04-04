
using Newt =  Newtonsoft.Json;
using Conv = Newtonsoft.Json.Converters;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Calebs.Extensions;

public static class JsonExtensions
{
    public static T FromJson<T>(this string json)
    {
        T result = default(T);
 #if NET7_0_OR_GREATER
        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter());

        result = JsonSerializer.Deserialize<T>(json, options);
#else
        result = Newt.JsonConvert.DeserializeObject<T>(json);
#endif
        return result;
    }

    public static string ToJson(this object o)
    {
        var result = string.Empty;
#if NET7_0_OR_GREATER
        var options = new JsonSerializerOptions ();
        options.Converters.Add(new JsonStringEnumConverter());
        result =  JsonSerializer.Serialize(o, options);
#else
        result = Newt.JsonConvert.SerializeObject(o, new Conv.StringEnumConverter());
#endif
        return result;
    }
}