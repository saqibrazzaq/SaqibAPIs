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
  [Table("State")]
  [Index(nameof(Name), [nameof(CountryId)], IsUnique = true)]
  public class State
  {
    [Key]
    public int Id { get; set; }
    [Required, MinLength(3)]
    public string? Name { get; set; }

    // Foreign keys
    public int? CountryId { get; set; }
    [ForeignKey(nameof(CountryId))]
    public virtual Country? Country { get; set; }
  }
}
