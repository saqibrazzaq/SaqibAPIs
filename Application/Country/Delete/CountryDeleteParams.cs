using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Country.Delete
{
  public class CountryDeleteParams
  {
    [Required]
    public int Id { get; set; }
  }
}
