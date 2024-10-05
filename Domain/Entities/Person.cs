using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  [Table("Person")]
  [Index(nameof(Email), IsUnique = true)]
  public class Person
  {
    [Key]
    public int Id { get; set; }
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
    public int? StateId { get; set; }
    [ForeignKey(nameof(StateId))]
    public State? State { get; set; }
  }
}
