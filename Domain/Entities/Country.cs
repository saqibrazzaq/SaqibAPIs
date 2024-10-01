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
  [Table("Country")]
  [Index(nameof(Name), IsUnique = true)]
  [Index(nameof(Code), IsUnique = true)]
  public class Country
  {
    [Key]
    public int Id { get; set; }
    [Required, MinLength(3)]
    public string? Name { get; set; }
    [MinLength(2)]
    public string? Code { get; set; }

    // Child tables
    public List<State> States { get; set; } = [];
  }
}
