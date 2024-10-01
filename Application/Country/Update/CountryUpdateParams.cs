using Application.Models.Country;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Country.Update
{
  public class CountryUpdateParams
  {
    [Required]
    public int Id { get; set; }
    [Required, MinLength(3)]
    public string? Name { get; set; }
    [MinLength(2)]
    public string? Code { get; set; }
  }
}
