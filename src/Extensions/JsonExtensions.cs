
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Calebs.Extensions;

public static class JsonExtensions
{
    public static T FromJson<T>(this string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
        //return JsonSerializer.Deserialize<T>(json);
    }

    //public static string ToJson(this object o)
    //{
    //    JsonSerializerOptions options = new() { };
    //    return JsonSerializer.Serialize(o, typeof(o), options);
    //}

    public static string ToJason(this object o)
    {
        //var cvt = new JsonStringEnumConverter();

        //JsonSerializerOptions options = new() {
        //    PropertyNameCaseInsensitive = true,
        //    IncludeFields= true,
        //    NumberHandling = JsonNumberHandling.AllowReadingFromString
        // };
        // options.Converters.Add(cvt);

        // Type T = o.GetType();
        // return JsonSerializer.Serialize(o, T, options);
        return JsonConvert.SerializeObject(o, new StringEnumConverter());
    }
}