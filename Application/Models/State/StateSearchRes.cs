using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Country;

namespace Application.Models.State
{
  public class StateSearchRes
  {
    public int Id { get; set; }
    public string? Name { get; set; }

    public int? CountryId { get; set; }
    public CountryRes? Country { get; set; }
  }
}
