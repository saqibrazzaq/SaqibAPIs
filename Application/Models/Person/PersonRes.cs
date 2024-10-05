using Application.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Models.Person
{
  public class PersonRes
  {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
    public string? Notes { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Gender { get; set; }
    public string? City { get; set; }
    [JsonConverter(typeof(NullableIntConverter))]
    public int? StateId { get; set; }
  }
}
