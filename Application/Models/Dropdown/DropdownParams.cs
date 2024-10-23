using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Models.Dropdown
{
  public class DropdownParams
  {
    public string? SearchText { get; set; } = string.Empty;
    [JsonConverter(typeof(NullableIntConverter))]
    public int? Id { get; set; }
  }
}
