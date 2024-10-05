using Application.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Person.Create
{
  public class PersonCreateParams
  {
    [Required, MinLength(2)]
    public string? FirstName { get; set; }
    public string? LastName { get; set; } = string.Empty;
    public string? Phone { get; set; } = string.Empty;
    [Required, EmailAddress]
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
    public string? Notes { get; set; } = string.Empty;
    public string? ImageUrl { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public string? Gender { get; set; } = string.Empty;
    public string? City { get; set; } = string.Empty;

    // Foreign keys
    [JsonConverter(typeof(NullableIntConverter))]
    public int? StateId { get; set; }
  }
}
