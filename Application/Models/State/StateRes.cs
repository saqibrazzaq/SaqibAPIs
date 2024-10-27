using Application.Common;
using Application.Models.Country;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Models.State
{
  public class StateRes
  {
    public int Id { get; set; }
    public string? Name { get; set; }

    [JsonConverter(typeof(NullableIntConverter))]
    public int? CountryId { get; set; }
    public CountryRes? Country { get; set; }
  }
}
