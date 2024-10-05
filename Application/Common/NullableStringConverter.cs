using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Common
{
  public class NullableStringConverter : JsonConverter<string?>
  {
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      var value = reader.GetString();
      if (string.IsNullOrEmpty(value))
        return null;
      else
        return value;
    }

    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
    {
      if (value == null)
        writer.WriteStringValue("");
      else
        writer.WriteStringValue(value);
    }
  }
}
