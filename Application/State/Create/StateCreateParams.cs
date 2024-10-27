using Application.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.State.Create
{
  public class StateCreateParams
  {
    [Required, MinLength(3)]
    public string? Name { get; set; }
    [JsonConverter(typeof(NullableIntConverter))]
    public int? CountryId { get; set; }
  }
}
