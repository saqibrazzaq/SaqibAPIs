using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Common
{
  public class NullableIntConverter : JsonConverter<int?>
  {
    public override bool HandleNull => true;

    public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      var value = reader.GetString();
      if (string.IsNullOrEmpty(value))
        return null;
      else
        return int.Parse(value);
    }

    public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
    {
      if (value == null)
        writer.WriteStringValue("");
      else
        writer.WriteStringValue(value.ToString());
    }
  }
}
