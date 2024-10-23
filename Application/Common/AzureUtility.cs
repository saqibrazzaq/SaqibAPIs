using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace Application.Common
{
  public class AzureUtility
  {
    public static T QueryStringToModel<T>(string? querystring) where T : new()
    {
      var dict = HttpUtility.ParseQueryString(querystring ?? "");
      var json = JsonSerializer.Serialize(
                          dict.AllKeys.ToDictionary(k => k, k => dict[k])
                 );
      var model = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
      {
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        PropertyNameCaseInsensitive = true
      });
      return model;
    }

    public static T DictionaryToModel<T>(Dictionary<string, object> dict) where T : new()
    {
      var json = JsonSerializer.Serialize(dict);
      var model = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
      {
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        PropertyNameCaseInsensitive = true
      });
      return model;
    }

    public async static Task<T> BodyToModel<T>(Stream body) where T : new()
    {
      var content = await new StreamReader(body).ReadToEndAsync();

      
      //var json = JsonSerializer.Serialize(dict);
      var model = JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
      {
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        PropertyNameCaseInsensitive = true
      });
      return model;
    }
  }
}
