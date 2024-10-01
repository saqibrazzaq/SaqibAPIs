using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Country.GetById
{
  public class CountryGetByIdParams
  {
    [Required]
    public int Id { get; set; }
  }
}
